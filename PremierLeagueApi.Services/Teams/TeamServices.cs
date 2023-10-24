using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
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

    public async Task<bool> UpdateTeamAsync(UpdateTeam teamModel)
    {
        var team = await _context.Team.FindAsync(teamModel.TeamId);
        if (team is null)
            return false;

        team.Name = teamModel.Name;
        team.Country = teamModel.Country;
        team.TeamId = teamModel.TeamId;

        await _context.SaveChangesAsync();
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
    public async Task<bool> AddPlayerToTeamAsync(int teamId, int playerId)
    {
        var team = await _dbContext.Teams
            .Include(t => t.PlayerList) 
            .FirstOrDefaultAsync(t => t.Id == teamId);

        if (team == null)
        {
            return false; 
        }

        var player = await _dbContext.Players
            .FirstOrDefaultAsync(p => p.Id == playerId);

        if (player == null)
        {
            return false; 
        }

        team.PlayerList.Add(player);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemovePlayerFromTeamAsync(int teamId, int playerId)
    {
        var team = await _dbContext.Teams
            .Include(t => t.PlayerList) 
            .FirstOrDefaultAsync(t => t.Id == teamId);

        if (team == null)
        {
            return false; 
        }

        var player = team.PlayerList.FirstOrDefault(p => p.Id == playerId);

        if (player == null)
        {
            return false; 
        }

        team.PlayerList.Remove(player);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<PlayerEntity>> GetPlayersInTeamAsync(int teamId)
    {
        return await _dbContext.Teams.PlayerList.ToList();

    }

}
