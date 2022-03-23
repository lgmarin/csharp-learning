using Microsoft.AspNetCore.Mvc;
using JwtWebapiTutorial.Models;
using System.Security.Cryptography;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace JwtWebapiTutorial.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    public static User user = new User();
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly UserContext _userContext;

    public AuthController(IConfiguration configuration, IUserService userService, UserContext userContext)
    {
        _configuration = configuration;
        _userService = userService;
        _userContext = userContext;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        CreatePassowrdHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        user.Username = request.Username;
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Role = request.Role;

        _userContext.User.Add(user);

        await _userContext.SaveChangesAsync();
        
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserDto request)
    {
        if (user.Username != request.Username)
        {
            return BadRequest("User not found!");
        }

        if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Password Incorrect!");
        }

        string token = CreateToken(user);

        return Ok(token);
    }

    [HttpGet("get"), Authorize]
    public ActionResult<string> GetUser()
    {
        var userName = _userService.GetName();
        return Ok(userName);
    }

    [HttpGet("admin-only"), Authorize(Roles = "Admin")]
    public ActionResult<string> AdminOnly()
    {
        var userName = _userService.GetName();
        return Ok(userName);
    }

    private string CreateToken(User user)
    {
        // Create the list of Claims for the token -- basic data
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        //Define payload for JWT
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
    private void CreatePassowrdHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using(var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using(var hmac = new HMACSHA512(user.PasswordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            // byte by byte check through SequenceEqual
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}