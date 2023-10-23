using PremierLeagueApi.Data.Entities;

public interface IPlayerStatsService
{
    Task<PlayerStats?> GetPlayerStatsByIdAsync(int playerStatsId);
    Task<List<PlayerStats>> GetAllPlayerStatsAsync();
    Task CreatePlayerStatsAsync(PlayerStats playerStats);
    Task UpdatePlayerStatsAsync(PlayerStats playerStats);
    Task DeletePlayerStatsAsync(int playerStatsId);
}
