using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Services.Teams;
using PremierLeagueApi.Models.Teams;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Services.Player;
using PremierLeagueApi.Services.ManagerService;
using PremierLeagueApi.Models.Player;


namespace PremierLeagueApi.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        private readonly IManagerService _managerService;

        public TeamController(ITeamService teamService, IPlayerService playerService, IManagerService managerService)
        {
            _teamService = teamService;
            _playerService = playerService;
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById([FromRoute] int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
            {
                return BadRequest();
            }
            return Ok(team);
        }

        [HttpGet("{name}:string")]
        public async Task<IActionResult> GetTeamByName([FromRoute] string name)
        {
            var team = await _teamService.GetTeamByNameAsync(name);
            if (team == null)
            {
                return BadRequest(new TextResponse($"Unable to find Team:{name}"));
            }
            return Ok();
        }

        [HttpGet("{city}:string")]
        public async Task<IActionResult> GetTeamsByCity([FromRoute] string city)
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

        [HttpPut("update")]
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

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeam selectedTeam)
        {
            if (selectedTeam is null)
            {
                return BadRequest(new TextResponse("Failed to create team"));
            }

            await _teamService.CreateTeamAsync(selectedTeam);
            return Ok(new TextResponse("Team has been successfully created."));
        }
        
        [HttpPost("addremovePlayer")]
        public async Task<IActionResult> UpdateTeamPlayer([FromBody] UpdateTeamPlayer model)
        {
            if (model == null)
            {
                return BadRequest(new TextResponse("Invalid player data"));
            }

            var team = await _teamService.GetTeamByIdAsync(model.TeamId);
            if (team == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }
            
            await _playerService.UpdateTeamPlayerAsync(model);
            return Ok(new TextResponse("Player added Successfully"));
        }

        [HttpGet("getplayers/{teamId}")]
        public async Task<IActionResult> GetPlayersInTeam([FromRoute] int teamId)
        {
            var existingTeam = await _teamService.GetTeamByIdAsync(teamId);
            if (existingTeam == null)
            {
                return NotFound(new TextResponse("Team not found"));
            }
            var playersInTeam = existingTeam.Players;
            return Ok(playersInTeam);
        }
        
        [HttpPost("addmanager")]
        public async Task<IActionResult> UpdateTeamManager([FromBody] UpdateTeamManager model)
        {
            var updateManager= _managerService.GetManagerByIdAsync(model.ManagerId);
            if (updateManager == null)
            {
                return BadRequest(new TextResponse("Invalid manager data"));
            }
            var existingTeam = await _teamService.GetTeamByIdAsync(model.TeamId);
            if (existingTeam == null)
            {
                return BadRequest(new TextResponse("Team not found"));
            }  
            // updateManager.TeamId = model.TeamId;          
            return Ok();
        }
    }
}
