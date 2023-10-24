using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Services.Teams;
using PremierLeagueApi.Models.Teams;
using PremierLeagueApi.Models.Responses;

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
                return BadRequest(new TextResponse("Unable to find/update Team."));
            }

            await _teamService.UpdateTeamAsync(selectedTeam);
            return Ok(new TextResponse("Team has been successfully updated."));
        }

        [HttpDelete("{teamId}")]
        public async Task<IActionResult> DeleteTeam(int teamId)
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
        public async Task<IActionResult> AddPlayerToTeam(int teamId, [FromBody] PlayerModel newPlayer)
        {
            if (newPlayer == null)
            {
                return BadRequest(new TextResponse("Invalid player data"));
            }


            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }

            var createdPlayer = await _playerService.CreatePlayer(newPlayer);
            existingTeam.PlayerList.Add(createdPlayer);

            await _teamService.UpdateTeam(teamId, existingTeam);

            return Ok(new TextResponse("Player added Successfully"))
        }

        [HttpDelete("{teamId}/removePlayer/{playerId}")]
        public async Task<IActionResult> RemovePlayerFromTeam(int teamId, int playerId)
        {
            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }

            var playerToRemove = existingTeam.PlayerList.FirstOrDefault(p => p.Id == playerId);
            if (playerToRemove == null)
            {
                return BadRequest(new TextResponse("Player not found in the team"));
            }

            existingTeam.PlayerList.Remove(playerToRemove);

            var result = await _teamService.UpdateTeam(teamId, existingTeam);

            if (!result)
            {
                return BadRequest(new TextResponse("Failed to update the team"));
            }

            return BadRequest(new TextResponse("Failed to remove"));
        }

        [HttpGet("{teamId}/players")]
        public async Task<IActionResult> GetPlayersInTeam(int teamId)
        {
            var existingTeam = await _teamService.GetTeamById(teamId);
            if (existingTeam == null)
            {
                return NotFound(new TextResponse("Team not found"));
            }

            var playersInTeam = existingTeam.PlayerList;

            return Ok(playersInTeam);
        }
    }
}
