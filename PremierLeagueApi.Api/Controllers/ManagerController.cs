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
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerService _managerService;

        public ManagerController(ManagerService managerService)
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
        public async Task<IActionResult> CreateManager(CreateManager managerModel)
        {
            if (managerModel == null)
            {
                return BadRequest();
            }

            await _managerService.CreateManagerAsync(managerModel);
            return Ok();
        }

        [HttpPut("{managerId}")]
        public async Task<IActionResult> UpdateManager(UpdateManager managerModel)
        {
            if (managerModel is null)
            {
                return BadRequest();
            }

            await _managerService.UpdateManagerAsync(managerModel);

            return NoContent();
        }

        [HttpDelete("{managerId}")]
        public async Task<IActionResult> DeleteManager(int managerId)
        {
            await _managerService.DeleteManagerAsync(managerId);
            return NoContent();
        }
    }
}
