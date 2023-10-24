using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Models.User;
using PremierLeagueApi.Services.User;

namespace PremierLeagueApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUser([FromBody] UserRegister model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createResult = await _userService.CreateUserAsync(model);
        if (createResult)
        {
            TextResponse response = new TextResponse("User was created successfully");
            return Ok(response);
        }

        return BadRequest(new TextResponse("User could not be created."));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}
