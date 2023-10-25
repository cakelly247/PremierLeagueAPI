using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.PlayerStatsModel;
using System.Threading.Tasks;

public interface IPlayerStatsService
{
    Task<bool> UpdatePlayerStats( UpdatePlayerStats updatePlayerStats);
    Task<PlayerStatsEntity?> GetPlayerStats(int playerId);
}
