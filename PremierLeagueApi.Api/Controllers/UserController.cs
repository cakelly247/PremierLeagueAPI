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
        if (users.Count == 0)
        {
            return NotFound(new TextResponse("There are currently no users in the database."));
        }

        return Ok(users);
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int userId)
    {
        await _userService.DeleteUserAsync(userId);
        return Ok(new TextResponse("User has been successfully deleted."));
    }
}
