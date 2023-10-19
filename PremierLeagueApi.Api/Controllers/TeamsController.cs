using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Services;
using PremierLeagueApi.Models;
using System.Threading.Tasks;
using PremierLeagueApi.Services.Teams;

namespace PremierLeagueApi.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet("findByName")]
        public async Task<IActionResult> GetTeamByName([FromQuery] string name)
        {
            var team = await _teamService.GetTeamByName(name);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        [HttpGet("findByCity")]
        public async Task<IActionResult> GetTeamsByCity([FromQuery] string city)
        {
            var teams = await _teamService.GetTeamsByCity(city);
            return Ok(teams);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] TeamModel updatedTeam)
        {
            var existingTeam = await _teamService.GetTeamById(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            // Update properties of existingTeam with data from updatedTeam
            // You can use a service method to perform the update

            // After updating, return the updated team
            return Ok(existingTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeam(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}