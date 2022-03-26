using ConsumeApi.Models;

namespace ConsumeApi.Services.UserService;

public interface IUserService
{
    string GetName();

    Task<List<UserDto>> GetAll();
    Task<UserDto> GetById(Guid userId);
    Task<UserDto> Update(Guid userId);
    Task<int> Remove(Guid userId);
    Task<UserDto> Insert();

    
}