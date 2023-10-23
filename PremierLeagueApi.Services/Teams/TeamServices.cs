

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

    public async Task<TeamEntity> CreateTeamAsync(TeamModel newTeam)
    {
    var teamEntity = new TeamEntity
    {
        TeamName = newTeam.TeamName,
        City = newTeam.City,
        Wins = newTeam.Wins,
        Losses = newTeam.Losses
    };
    _dbContext.Teams.Add(teamEntity);
    await _dbContext.SaveChangesAsync();
    return teamEntity;
    }


    public async Task<List<TeamEntity>> GetAllTeamsAsync()
        {
            return await _dbContext.Teams.ToListAsync();
        }

        public async Task<TeamEntity?> GetTeamByIdAsync(int teamId)
        {
            return await _dbContext.Teams.FindAsync(teamId);
        }

        public async Task<TeamEntity?> GetTeamByNameAsync(string teamName)
        {
            return await _dbContext.Teams.FirstOrDefaultAsync(t => t.TeamName == teamName);
        }

        public async Task<List<TeamEntity>> GetTeamsByCityAsync(string city)
        {
            return await _dbContext.Teams.Where(t => t.City == city).ToListAsync();
        }

        //Change Update Team like Germaynes and create update team models
        public async Task<bool> UpdateTeamAsync(int teamId, TeamEntity updatedTeam)
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
        

        public async Task<bool> DeleteTeamAsync(int teamId)
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
