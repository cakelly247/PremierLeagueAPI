using PremierLeagueApi.Models.Player;

namespace PremierLeagueApi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
    }
}