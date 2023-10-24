using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Models.Teams;

namespace PremierLeagueApi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
        Task<PlayerEntity?> GetPlayerByIdAsync(int playerId);
        Task<List<PlayerEntity>>? GetAllPlayersAsync();
        Task<bool> UpdatePlayerAsync(PlayerUpdate updateModel);
        Task<bool> UpdateTeamPlayerAsync(UpdateTeamPlayer model);
        Task<bool> DeletePlayerAsync(int playerId);
    }
}