using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremierLeagueApi.Data;
using PremierLeagueApi.Models;
public interface IManagerService
{

    Task<ManagerEntity> GetManagerByIdAsync(int managerId);
    Task<List<ManagerEntity>> GetAllManagersAsync();
    Task<bool> CreateManagerAsync(CreateManager managerModel);
    Task<bool> UpdateManagerAsync(UpdateManager managerModel);
    Task DeleteManagerAsync(int managerId);
}
