using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Services.Teams;

public interface ITeamService
{
    Task<List<TeamEntity>> GetAllTeamsAsync();
        Task<TeamEntity?> GetTeamByIdAsync(int teamId);
        Task<TeamEntity?> GetTeamByNameAsync(string teamName);
        Task<List<TeamEntity>> GetTeamsByCityAsync(string city);
        Task<bool> UpdateTeamAsync(int teamId, TeamEntity updatedTeam);
        Task<bool> DeleteTeamAsync(int teamId);
        Task<TeamEntity> CreateTeamAsync(TeamModel, newTeam);
        Task<bool> AddPlayerToTeamAsync(int teamId, int playerId);
        Task<bool> RemovePlayerFromTeamAsync(int teamId, int playerId);
        Task<List<PlayerEntity>> GetPlayersInTeamAsync(int teamId);
}