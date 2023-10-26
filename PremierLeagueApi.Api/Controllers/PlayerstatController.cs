using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.PlayerStatsModel;
using System;
using System.Threading.Tasks;

namespace PremierLeagueApi.Controllers
{
    [Route("api/playerstats")]
    [ApiController]
    public class PlayerStatsController : ControllerBase
    {
        private readonly IPlayerStatsService _playerStatsService;

        public PlayerStatsController(IPlayerStatsService playerStatsService)
        {
            _playerStatsService = playerStatsService;
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayerStats([FromBody] UpdatePlayerStats updateModel)
        {
            if (updateModel is null)
            {
                return BadRequest();
            } 

            await _playerStatsService.UpdatePlayerStatsAsync(updateModel);
            return Ok();
        }

        [HttpGet("{playerId}")]
        public async Task<IActionResult> GetPlayerStats([FromRoute] int playerId)
        {
            var playerStats = await _playerStatsService.GetPlayerStatsByIdAsync(playerId);

            if (playerStats == null)
            {
                return NotFound("Player stats not found");
            }

            return Ok(playerStats);
        }
    }
}
