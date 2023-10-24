using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Services.Teams;
using PremierLeagueApi.Models.Teams;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Services.Player;

namespace PremierLeagueApi.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public TeamController(ITeamService teamService,
                            IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return BadRequest();
            }

            return Ok(team);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetTeamByName([FromQuery] string name)
        {
            var team = await _teamService.GetTeamByNameAsync(name);
            if (team == null)
            {
                return BadRequest(new TextResponse($"Unable to find Team:{name}"));
            }

            return Ok();
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetTeamsByCity([FromQuery] string city)
        {
            var teams = await _teamService.GetTeamsByCityAsync(city);
            if (teams is null)
            {
                return BadRequest(new TextResponse("Unable to find Team(s)."));
            }
            else if (teams.Count == 0)
            {
                return NotFound(new TextResponse($"{city} currently has no Teams." ));
            }

            return Ok(teams);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeam selectedTeam)
        {
            if (selectedTeam is null)
            {
                return BadRequest(new TextResponse("Unable to update Team."));
            }

            await _teamService.UpdateTeamAsync(selectedTeam);
            return Ok(new TextResponse("Team has been successfully updated."));
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam([FromRoute] int teamId)
        {
            await _teamService.DeleteTeamAsync(teamId);
            return Ok(new TextResponse("Team has been successfully deleted."));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeam selectedTeam)
        {
            if (selectedTeam is null)
            {
                return BadRequest(new TextResponse("Failed to create team"));
            }

            await _teamService.CreateTeamAsync(selectedTeam);
            return Ok(new TextResponse("Team has been successfully created."));
        }
        
        [HttpPost("{teamId}/addPlayer")]
        public async Task<IActionResult> AddPlayerToTeam(int teamId, int playerId)
        {
            var newPlayer = _playerService.GetPlayerByIdAsync(playerId);
            if (newPlayer == null)
            {
                return BadRequest(new TextResponse("Invalid player data"));
            }

            var team = await _teamService.GetTeamByIdAsync(teamId);
            if (team == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }
            
            return Ok(new TextResponse("Player added Successfully"));
        }

        [HttpDelete("{teamId}/removePlayer/{playerId}")]
        public async Task<IActionResult> RemovePlayerFromTeam(int teamId, int playerId)
        {
            var existingTeam = await _teamService.GetTeamByIdAsync(teamId);
            if (existingTeam == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }

            var playerToRemove = existingTeam.Players!.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove == null)
            {
                return BadRequest(new TextResponse("Player not found in the team"));
            }

            existingTeam.Players!.Remove(playerToRemove);
            return Ok(new TextResponse("Player removed successfully"));
        }

        [HttpGet("{teamId}/players")]
        public async Task<IActionResult> GetPlayersInTeam(int teamId)
        {
            var existingTeam = await _teamService.GetTeamByIdAsync(teamId);
            if (existingTeam == null)
            {
                return NotFound(new TextResponse("Team not found"));
            }

            var playersInTeam = existingTeam.Players;

            return Ok(playersInTeam);
        }
    }
}
