using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Services.Player;

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

    [HttpPost("create")]
    public async Task<IActionResult> CreatePlayer([FromBody] PlayerCreate model)
    {
        if (model is null)
        {
            return BadRequest(new TextResponse("Unable to create player."));
        }

        await _playerService.CreatePlayerAsync(model);
        TextResponse response = new("Player was created Successfully.");
        return Ok(response);
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> GetPlayerById([FromRoute] int playerId)
    {
        var player = await _playerService.GetPlayerByIdAsync(playerId);
        if (player is null)
        {
            return BadRequest(new TextResponse($"Unable to find player with Id:{playerId}"));
        }

        return Ok(player);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var players = await _playerService.GetAllPlayersAsync()!;
        if (players is null)
        {
            return BadRequest(new TextResponse("Unable to process request."));
        }
        else if (players.Count == 0)
        {
            return BadRequest(new TextResponse("There are currently no players in the database."));
        }

        return Ok(players);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePlayer([FromBody] PlayerUpdate updateModel)
    {
        if (updateModel is null)
        {
            return BadRequest(new TextResponse("Unable to update player."));
        }

        await _playerService.UpdatePlayerAsync(updateModel);
        return Ok(new TextResponse("Player has been successfully updated."));
    }

    [HttpDelete("{playerId}")]
    public async Task<IActionResult> DeletePlayerFromDb([FromRoute] int playerId)
    {
        await _playerService.DeletePlayerAsync(playerId);
        return Ok(new TextResponse("Player has been successfully deleted from the database."));
    }
}
