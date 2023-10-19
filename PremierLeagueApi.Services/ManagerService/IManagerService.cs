using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremierLeagueApi.Data;
using PremierLeagueApi.Models;
public interface IManagerService
{
    Task<Manager> GetManagerByIdAsync(int managerId);
    Task<List<Manager>> GetAllManagersAsync();
    Task CreateManagerAsync(Manager manager);
    Task UpdateManagerAsync(Manager manager);
    Task DeleteManagerAsync(int managerId);
}
