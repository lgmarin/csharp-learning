using ConsumeApi.Models;
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

    [Route("user/{id}"), HttpGet]
    public  async Task<ActionResult<UserDto>> GetById(Guid userId)
    {
        var user = await _userService.GetById(userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user"), HttpGet]
    public  async Task<ActionResult<List<UserDto>>> GetAll()
    {
        var user = await _userService.GetAll();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user/update/{id}"), HttpPut]
    public  async Task<ActionResult<UserDto>> Update(Guid userId)
    {
        var user = await _userService.GetAll();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user/{id}"), HttpDelete]
    public  async Task<ActionResult<int>> Remove(Guid userId)
    {
        var user = await _userService.GetAll();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [Route("user/add"), HttpPost]
    public  async Task<ActionResult<UserDto>> Insert(Guid userId)
    {
        var user = await _userService.GetAll();

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

}