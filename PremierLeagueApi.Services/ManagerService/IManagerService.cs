using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using PremierLeagueApi.Data;
using PremierLeagueApi.Models;
public interface IManagerService
{
    Task<CreateManager> GetManagerByIdAsync(int managerId);
    Task<List<CreateManager>> GetAllManagersAsync();
    Task CreateManagerAsync(CreateManager manager);
    Task UpdateManagerAsync(UpdateManager manager);
    Task DeleteManagerAsync(int managerId);
}
