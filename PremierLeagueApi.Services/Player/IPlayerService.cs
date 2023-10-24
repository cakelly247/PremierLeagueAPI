using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Player;

namespace PremierLeagueApi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
        Task<PlayerEntity?> GetPlayerByIdAsync(int playerId);
        Task<List<PlayerEntity>>? GetAllPlayersAsync();
        Task<bool> UpdatePlayerAsync(PlayerUpdate updateModel);
        Task<bool> DeletePlayerAsync(int playerId);
    }
}