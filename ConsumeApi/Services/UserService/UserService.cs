using System.Security.Claims;
using ConsumeApi.Data;
using ConsumeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumeApi.Services.UserService;

public class UserService : IUserService
{
    public static User user = new User();
    private readonly UserContext _userContext;
    private readonly IPasswordService _passwordService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(UserContext userContext, IPasswordService passwordService, IHttpContextAccessor httpContextAccessor)
    {
        _userContext = userContext;
        _passwordService = passwordService;
        _httpContextAccessor = httpContextAccessor;
    }

    public IQueryable<UserViewDto> GetAll()
    {
        var users = from u in _userContext.User
                    select new UserViewDto()
                    {
                        ID = u.ID,
                        Username = u.Username,
                        Role = u.Role
                    };

        return users;
    }
    
    public async Task<UserViewDto> GetById(Guid userId)
    {
        var user = await _userContext.User.Select(u =>
                    new UserViewDto()
                    {
                        ID = u.ID,
                        Username = u.Username,
                        Role = u.Role
                    }).FirstOrDefaultAsync(u => u.ID == userId);

        return user;
    }

    public async Task<UserViewDto> Update(Guid userId, UserDto userDto)
    {
        _userContext.Entry(userDto).State = EntityState.Modified;

        try
        {
            await _userContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(userId))
            {
                throw new DbUpdateConcurrencyException("There is no user in the DB that matches the provided Id.");
            }
            else
            {
                throw;
            }
        }

        var updateduser = await _userContext.User.Select(u =>
                        new UserViewDto()
                            {
                                ID = u.ID,
                                Username = u.Username,
                                Role = u.Role
                            }).FirstOrDefaultAsync(u => u.ID == userId);

        return updateduser;
    }

    public async Task<int> Remove(Guid userId)
    {
        User user = await _userContext.User.FindAsync(userId);

        if (user == null)
        {
            return 0;
        }

        _userContext.User.Remove(user);
        await _userContext.SaveChangesAsync();

        return 1;
    }

    public async Task<UserViewDto> Insert(UserDto userDto)
    {
        _passwordService.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

        user.ID = new Guid();
        user.Username = userDto.Username;
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.Role = userDto.Role;

        _userContext.User.Add(user);

        await _userContext.SaveChangesAsync();

        var newuser = new UserViewDto()
        {
            ID = user.ID,
            Username = user.Username,
            Role = user.Role
        };

        return newuser;
    }
    private bool UserExists(Guid userId)
    {
        return _userContext.User.Count(u => u.ID == userId) > 0;
    }    
    public string GetId()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
        return result;
    }
    public bool IsAdmin()
    {
        var role = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            if (role == "admin")
            {
                return true;
            }
        }
        return false;
    }    
}