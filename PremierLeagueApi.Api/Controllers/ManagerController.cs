using Microsoft.AspNetCore.Mvc;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models;
using PremierLeagueApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return Ok(managers);
        }

        [HttpGet("{managerId}")]
        public async Task<ActionResult<ManagerEntity>> GetManager(int managerId)
        {
            var manager = await _managerService.GetManagerByIdAsync(managerId);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateManager([FromBody] CreateManager managerModel)
        {
            if (managerModel == null)
            {
                return BadRequest();
            }

            await _managerService.CreateManagerAsync(managerModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManager([FromBody] UpdateManager managerModel)
        {
            if (managerModel is null)
            {
                return BadRequest();
            }

            await _managerService.UpdateManagerAsync(managerModel);

            return Ok();
        }

        [HttpDelete("{managerId}")]
        public async Task<IActionResult> DeleteManager(int managerId)
        {
            await _managerService.DeleteManagerAsync(managerId);
            return NoContent();
        }
    }
}
