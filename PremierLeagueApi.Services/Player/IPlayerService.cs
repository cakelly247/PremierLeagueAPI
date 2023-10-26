using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Models.Teams;

namespace PremierLeagueApi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
        Task<List<PlayerEntity>?> GetAllPlayersAsync();
        Task<PlayerEntity?> GetPlayerByIdAsync(int playerId);
        Task<List<PlayerEntity>?> GetPlayersByTeamAsync(int teamId);
        Task<bool> UpdatePlayerAsync(PlayerUpdate updateModel);
        Task<bool> UpdateTeamPlayerAsync(UpdateTeamPlayer model);
        Task<bool> DeletePlayerAsync(int playerId);
    }
}