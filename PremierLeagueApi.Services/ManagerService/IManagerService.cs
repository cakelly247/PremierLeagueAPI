using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.ManagersModel;

namespace PremierLeagueApi.Services.ManagerService;

public interface IManagerService
{
    Task<ManagerEntity?> GetManagerByIdAsync(int managerId);
    Task<List<ManagerEntity>> GetAllManagersAsync();
    Task<bool> CreateManagerAsync(CreateManager managerModel);
    Task<bool> UpdateManagerAsync(int managerId, UpdateManager updatedManager);
    Task DeleteManagerAsync(int managerId);
}
