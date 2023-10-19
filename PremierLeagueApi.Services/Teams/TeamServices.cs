

using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Services.Teams;

namespace PremierLeagueApi.Services;

public class TeamServices : ITeamService
{
    private readonly PLDbContext _dbContext;

    public TeamServices(PLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<TeamEntity>> GetAllTeams()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<TeamEntity> GetTeamById(int teamId)
        {
            return await _dbContext.Teams.FindAsync(teamId);
        }

        public async Task<TeamEntity> GetTeamByName(string teamName)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(t => t.TeamName == teamName);
        }

        public async Task<List<TeamEntity>> GetTeamsByCity(string city)
        {
            return await _dbContext.Teams.Where(t => t.City == city).ToListAsync();
        }

        public async Task<bool> UpdateTeam(int teamId, TeamEntity updatedTeam)
        {
            var existingTeam = await _dbContext.Teams.FindAsync(teamId);
            if (existingTeam == null)
            {
                return false;
            }
            existingTeam.TeamName = updatedTeam.TeamName;
            existingTeam.City = updatedTeam.City;
            existingTeam.Wins = updatedTeam.Wins;
            existingTeam.Losses = updatedTeam.Losses;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTeam(int teamId)
        {
            var team = await _dbContext.Teams.FindAsync(teamId);
            if (team == null)
            {
                return false;
            }

            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
