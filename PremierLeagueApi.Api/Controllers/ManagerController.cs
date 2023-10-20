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
        public async Task<ActionResult<IEnumerable<Manager>>> GetAllManagers()
        {
            var managers = await _managerService.GetAllManagersAsync();
            return Ok(managers);
        }

        [HttpGet("{managerId}")]
        public async Task<ActionResult<Manager>> GetManager(int managerId)
        {
            var manager = await _managerService.GetManagerByIdAsync(managerId);

            if (manager == null)
            {
                return NotFound();
            }

            return Ok(manager);
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> CreateManager(Manager manager)
        {
            if (manager == null)
            {
                return BadRequest();
            }

            await _managerService.CreateManagerAsync(manager);
            return CreatedAtAction("GetManager", new { managerId = manager.ManagerId }, manager);
        }

        [HttpPut("{managerId}")]
        public async Task<IActionResult> UpdateManager(int managerId, Manager manager)
        {
            if (managerId != manager.ManagerId)
            {
                return BadRequest();
            }

            await _managerService.UpdateManagerAsync(manager);

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
