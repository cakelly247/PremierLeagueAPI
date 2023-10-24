using PremierLeagueApi.Data.Entities;

public interface IPlayerStatsService
{
    Task<PlayerStatsEntity?> GetPlayerStatsByIdAsync(int playerId);
    Task<List<PlayerStatsEntity>> GetAllPlayerStatsAsync();
    Task CreatePlayerStatsAsync(PlayerStatsEntity playerStats);
    Task UpdatePlayerStatsAsync(PlayerStatsEntity playerStats);
    Task DeletePlayerStatsAsync(int playerId);
}
