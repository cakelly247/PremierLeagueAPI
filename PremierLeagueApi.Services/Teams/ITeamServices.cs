using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Teams;

namespace PremierLeagueApi.Services.Teams;

public interface ITeamService
{
    Task<bool> CreateTeamAsync(CreateTeam newTeam);
    Task<List<TeamEntity>> GetAllTeamsAsync();
    Task<TeamEntity?> GetTeamByIdAsync(int teamId);
    Task<TeamEntity?> GetTeamByNameAsync(string teamName);
    Task<List<TeamEntity>> GetTeamsByCityAsync(string city);
    Task<bool> UpdateTeamAsync(UpdateTeam updatedTeam);
    Task DeleteTeamAsync(int teamId);
    Task<bool> UpdateTeamPlayerAsync(UpdateTeamPlayer model);
    Task<List<PlayerEntity>> GetPlayersInTeamAsync(int teamId);
    Task<bool> UpdateTeamManagerAsync(UpdateTeamManager model);

}