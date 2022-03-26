using System.Security.Claims;
using ConsumeApi.Models;

namespace ConsumeApi.Services.UserService;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string GetName()
    {
        var result = string.Empty;
        if (_httpContextAccessor.HttpContext != null)
        {
            result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        return result;
    }

    public async Task<List<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }
    
    public async Task<UserDto> GetById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Update(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Remove(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> Insert()
    {
        throw new NotImplementedException();
    }    
}