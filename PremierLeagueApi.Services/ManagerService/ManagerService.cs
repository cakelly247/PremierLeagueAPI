using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.ManagersModel;

namespace PremierLeagueApi.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly PLDbContext _context;

        public ManagerService(PLDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerEntity?> GetManagerByIdAsync(int managerId)
        {
            return await _context.Managers.FindAsync(managerId);
        }

        public async Task<List<ManagerEntity>> GetAllManagersAsync()
        {
            return await _context.Managers.ToListAsync();
        }

        public async Task<bool> CreateManagerAsync(CreateManager managerModel)
        {
            ManagerEntity entity = new ManagerEntity()
            {
                Name = managerModel.Name,
                Country = managerModel.Country,
                TeamId = 13
            };

            await _context.Managers.AddAsync(entity);
            var success = await _context.SaveChangesAsync();
            return success != 0 ? true : false;
        }

        public async Task<bool> UpdateManagerAsync(UpdateManager selectedManager)
        {
            var manager = await _context.Managers.FindAsync(selectedManager.ManagerId);
            if (manager is null)
                return false;

            manager.Name = selectedManager.Name;
            manager.Country = selectedManager.Country;
            manager.TeamId = selectedManager.TeamId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteManagerAsync(int managerId)
        {
            var manager = await GetManagerByIdAsync(managerId);
            if (manager != null)
            {
                _context.Managers.Remove(manager);
                await _context.SaveChangesAsync();
            }
        }
    }
}
