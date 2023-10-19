using PremierLeagueApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPlayerStatsService
{
    Task<PlayerStats> GetPlayerStatsByIdAsync(int playerStatsId);
    Task<List<PlayerStats>> GetAllPlayerStatsAsync();
    Task CreatePlayerStatsAsync(PlayerStats playerStats);
    Task UpdatePlayerStatsAsync(PlayerStats playerStats);
    Task DeletePlayerStatsAsync(int playerStatsId);
}
