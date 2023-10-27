using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.ManagersModel;
using PremierLeagueApi.Models.Responses;
using PremierLeagueApi.Services.ManagerService;

namespace PremierLeagueApi.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerEntity>>> GetAllManagers()
        {
            var managers = await _managerService.GetAllManagersAsync();
            if (managers.Count == 0)
            {
                return NotFound(new TextResponse("There are currently no managers in the database."));
            }

            return Ok(managers);
        }

        [HttpGet("{managerId}")]
        public async Task<ActionResult<ManagerEntity>> GetManager([FromRoute] int managerId)
        {
            var manager = await _managerService.GetManagerByIdAsync(managerId);
            if (manager is null)
            {
                return NotFound(new TextResponse($"Unable to find manager with Id: {managerId}."));
            }

            return Ok(manager);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateManager([FromBody] CreateManager managerModel)
        {
            if (managerModel is null)
            {
                return BadRequest(new TextResponse("Unable to create manager."));
            }

            await _managerService.CreateManagerAsync(managerModel);
            TextResponse response = new("Manager was created Successfully.");
            return Ok(response);
        }

        [HttpPut("{managerId}")]
        public async Task<IActionResult> UpdateManager([FromRoute] int managerId, [FromBody] UpdateManager updatedManager)
        {
            if (updatedManager is null)
            {
                return BadRequest(new TextResponse("Invalid input. Unable to update manager."));
            }

            var success = await _managerService.UpdateManagerAsync(managerId, updatedManager);
            if (success)
            {
                return Ok(new TextResponse("Manager has been successfully updated."));
            }

            return BadRequest(new TextResponse($"Unable to find manager with Id:{managerId}."));
        }

        [HttpDelete("{managerId}")]
        public async Task<IActionResult> DeleteManager([FromRoute] int managerId)
        {
            await _managerService.DeleteManagerAsync(managerId);
            return Ok(new TextResponse("Manager deleted successfully."));
        }
    }
}
