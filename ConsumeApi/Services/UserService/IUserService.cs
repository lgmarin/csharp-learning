using ConsumeApi.Models;

namespace ConsumeApi.Services.UserService;

public interface IUserService
{
    IQueryable<UserViewDto> GetAll();
    Task<UserViewDto> GetById(Guid userId);
    Task<UserViewDto> Update(Guid userId, UserDto userDto);
    Task<int> Remove(Guid userId);
    Task<UserViewDto> Insert(UserDto userDto);
    string GetId();
    bool IsAdmin();

}