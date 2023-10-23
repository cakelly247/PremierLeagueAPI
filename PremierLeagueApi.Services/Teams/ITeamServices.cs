using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Services.Teams;

public interface ITeamService
{
    Task<List<TeamEntity>> GetAllTeams();
        Task<TeamEntity?> GetTeamById(int teamId);
        Task<TeamEntity?> GetTeamByName(string teamName);
        Task<List<TeamEntity>> GetTeamsByCity(string city);
        Task<bool> UpdateTeam(int teamId, TeamEntity updatedTeam);
        Task<bool> DeleteTeam(int teamId);
}