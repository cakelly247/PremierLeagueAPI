using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Teams;
using PremierLeagueApi.Services.Teams;

namespace PremierLeagueApi.Services;

public class TeamServices : ITeamService
{
    private readonly PLDbContext _dbContext;

    public TeamServices(PLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateTeamAsync(CreateTeam newTeam)
    {
        var teamEntity = new TeamEntity
        {
            TeamName = newTeam.TeamName,
            City = newTeam.City,
            Wins = newTeam.Wins,
            Losses = newTeam.Losses
        };
        
        _dbContext.Teams.Add(teamEntity);
        var success = await _dbContext.SaveChangesAsync();
        return success != 0 ? true : false;
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

    public async Task<bool> UpdateTeamAsync(UpdateTeam selectedTeam)
    {
        var team = await _dbContext.Teams.FindAsync(selectedTeam);
        if (team is null)
        {
            return false;
        }

        team.TeamName = selectedTeam.TeamName;
        team.City = selectedTeam.City;
        team.Wins = selectedTeam.Wins;
        team.Losses = selectedTeam.Losses;
        team.ManagerId = selectedTeam.ManagerId;

        await _dbContext.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AddPlayerToTeamAsync(int teamId, int playerId)
    {
        var team = await _dbContext.Teams
            .Include(t => t.Players) 
            .FirstOrDefaultAsync(t => t.TeamId == teamId);

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

        team.Players!.Add(player);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> RemovePlayerFromTeamAsync(int teamId, int playerId)
    {
        var team = await _dbContext.Teams
            .Include(t => t.Players) 
            .FirstOrDefaultAsync(t => t.TeamId == teamId);

        if (team == null)
        {
            return false; 
        }

        var player = team.Players!.FirstOrDefault(p => p.Id == playerId);

        if (player == null)
        {
            return false; 
        }

        team.Players!.Remove(player);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<PlayerEntity>> GetPlayersInTeamAsync(int teamId)
    {
        return await _dbContext.Players.Where(p => p.TeamId == teamId).ToListAsync();
    }

    public async Task DeleteTeamAsync(int teamId)
    {
        var team = await GetTeamByIdAsync(teamId);
        if (team is not null)
        {
            _dbContext.Teams.Remove(team);
            await _dbContext.SaveChangesAsync();
        }
    }
}
