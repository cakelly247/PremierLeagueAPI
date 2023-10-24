using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Services;
using PremierLeagueApi.Models;
using System.Threading.Tasks;
using PremierLeagueApi.Services.Teams;
using PremierLeagueApi.Models.Teams;

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
                return BadRequest();
            }

            return Ok(team);
        }

        [HttpGet("findByName")]
        public async Task<IActionResult> GetTeamByName([FromQuery] string name)
        {
            var team = await _teamService.GetTeamByName(name);
            if (team == null)
            {
                return BadRequest();
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
                return BadRequest();
            }

            return Ok(existingTeam);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeam(id);
            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] TeamModel newTeam)
        {
            var createdTeam = await _teamService.CreateTeam(newTeam);
            if (createdTeam == null)
            {
                return BadRequest("Failed to create team")
            }

            return TextResponse response = new response("Team created Successfully")
        }

        [HttpPost("{teamId}/addPlayer")]
        public async Task<IActionResult> AddPlayerToTeam(int teamId, [FromBody] PlayerModel newPlayer)
        {
            if (newPlayer == null)
            {
                return BadRequest("Invalid player data");
            }


            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return BadRequest("Team not found");
            }

            var createdPlayer = await _playerService.CreatePlayer(newPlayer);
            existingTeam.PlayerList.Add(createdPlayer);

            await _teamService.UpdateTeam(teamId, existingTeam);

            return TextResponse response = new response("Player added Successfully")
        }

        [HttpDelete("{teamId}/removePlayer/{playerId}")]
        public async Task<IActionResult> RemovePlayerFromTeam(int teamId, int playerId)
        {
            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return BadRequest("Team not found");
            }

            var playerToRemove = existingTeam.PlayerList.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove == null)
            {
                return BadRequest("Player not found in the team");
            }

            existingTeam.PlayerList.Remove(playerToRemove);

            var result = await _teamService.UpdateTeam(teamId, existingTeam);

            if (!result)
            {
                return BadRequest("Failed to update the team");
            }

            return BadRequest("Failed to remove");
        }

        [HttpGet("{teamId}/players")]
        public async Task<IActionResult> GetPlayersInTeam(int teamId)
        {
            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return NotFound("Team not found");
            }

            var playersInTeam = existingTeam.PlayerList;

            return Ok(playersInTeam);
        }


    }
}
