using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Data.Entities;

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

        [HttpGet]
        public async Task<IActionResult> GetAllPlayerStats()
        {
            var playerStats = await _playerStatsService.GetAllPlayerStatsAsync();
            return Ok(playerStats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerStats(int id)
        {
            var playerStats = await _playerStatsService.GetPlayerStatsByIdAsync(id);

            if (playerStats == null)
            {
                return NotFound();
            }

            return Ok(playerStats);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayerStats([FromBody] PlayerStatsEntity playerStats)
        {
            await _playerStatsService.CreatePlayerStatsAsync(playerStats);
            return CreatedAtAction(nameof(GetPlayerStats), new { id = playerStats.PlayerId }, playerStats);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerStats(int id, [FromBody] PlayerStatsEntity playerStats)
        {
            if (id != playerStats.PlayerId)
            {
                return BadRequest();
            }

            var existingPlayerStats = await _playerStatsService.GetPlayerStatsByIdAsync(id);

            if (existingPlayerStats == null)
            {
                return NotFound();
            }

            await _playerStatsService.UpdatePlayerStatsAsync(playerStats);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerStats(int id)
        {
            var existingPlayerStats = await _playerStatsService.GetPlayerStatsByIdAsync(id);

            if (existingPlayerStats == null)
            {
                return NotFound();
            }

            await _playerStatsService.DeletePlayerStatsAsync(id);

            return NoContent();
        }
    }
}

