using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremierLeagueApi.Data;
using PremierLeagueApi.Models;

namespace PremierLeagueApi.Services
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

        public async Task CreateManagerAsync(ManagerEntity manager)
        {
            _context.Managers.Add(manager);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManagerAsync(ManagerEntity manager)
        {
            _context.Managers.Update(manager);
            await _context.SaveChangesAsync();
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
