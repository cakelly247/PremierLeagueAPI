using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.PlayerStatsModel;
using System.Threading.Tasks;

public interface IPlayerStatsService
{
    Task<bool> UpdatePlayerStatsAsync(UpdatePlayerStats model);
    Task<PlayerStatsEntity?> GetPlayerStatsByIdAsync(int playerId);
}
