using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Services.Player;
using PremierLeagueApi.Services.User;

namespace PremierLeagueApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreate model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var createResult = await _playerService.CreatePlayerAsync(model);
        if (createResult)
        {
            TextResponse response = new("Player was created Successfully.");
            return Ok(response);
        }

        return BadRequest(new TextResponse("Player could not be created."));
    }
}
