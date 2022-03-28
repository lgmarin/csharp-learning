using ConsumeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeApi.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;


    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [Route("user/{userId}"), HttpGet]
    [Authorize]
    public  async Task<ActionResult<UserViewDto>> GetById(Guid userId)
    {
        if (userId == null)
        {
            return BadRequest();
        }

        if (_userService.GetId() != userId.ToString() || !_userService.IsAdmin())
        {
           return Unauthorized("You are not the owner of this account and you are not an Administrator!"); 
        }

        var user = await _userService.GetById(userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user"), HttpGet]
    public  async Task<ActionResult<IEnumerable<UserViewDto>>> GetAll()
    {
        var users = _userService.GetAll();

        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
    }

    [Route("user/update/{userId}"), HttpPut]
    [Authorize]
    public  async Task<ActionResult<UserViewDto>> Update(Guid userId, UserDto userDto)
    {
        if (userDto == null)
        {
            return BadRequest();
        }
        
        if (_userService.GetId() != userId.ToString())
        {
           return Unauthorized("You are not the owner of this account!"); 
        }        

        var updateduser = await _userService.Update(userId, userDto);

        if (updateduser == null)
        {
            return NotFound();
        }

        return Ok(updateduser);
    }

    [Route("user/{userId}"), HttpDelete]
    [Authorize]
    public  async Task<ActionResult<int>> Remove(Guid userId)
    {
        if (userId == null)
        {
            return BadRequest();
        }

        if (_userService.GetId() != userId.ToString())
        {
           return Unauthorized("You are not the owner of this account!"); 
        }        
        
        var user = await _userService.Remove(userId);

        if (user == 0)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user/add"), HttpPost]
    public  async Task<ActionResult<UserViewDto>> Insert(UserDto user)
    {
        var newuser = await _userService.Insert(user);        

        if (user == null)
        {
            return NotFound();
        }

        return Ok(newuser);
    }

}