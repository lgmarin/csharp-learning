using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using ConsumeApi.Models;
using ConsumeApi.Services.PasswordService;
using ConsumeApi.Data;

namespace ConsumeApi.Controllers;

[ApiController]
[Route("auth/[controller]")]
public class AuthenticationController : ControllerBase
{
    public static User user = new User();
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly UserContext _userContext;
    private readonly IPasswordService _passwordService;

    public AuthenticationController(IConfiguration configuration, IUserService userService, UserContext userContext, IPasswordService passwordService)
    {
        _configuration = configuration;
        _userService = userService;
        _userContext = userContext;
        _passwordService = passwordService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request)
    {
        _passwordService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        user.ID = new Guid();
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

        if (!_passwordService.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return BadRequest("Password Incorrect!");
        }

        string token = CreateToken(user);

        return Ok(token);
    }

    private string CreateToken(User user)
    {
        // Create the list of Claims for the token -- basic data
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.ID.ToString()),
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

}