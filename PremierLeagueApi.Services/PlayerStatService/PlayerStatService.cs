using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.PlayerStatsModel;
using System;
using System.Threading.Tasks;

public class PlayerStatsService : IPlayerStatsService
{
    private readonly PLDbContext _context;

    public PlayerStatsService(PLDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> UpdatePlayerStats(UpdatePlayerStats model)
    {
        var player = await _context.PlayerStats.FindAsync(model.PlayerId);

        if (player == null)
        {
            return false;
        }

        
        player.Goals = model.Goals;
        player.Assists = model.Assists;
        player.Saves = model.Saves;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<PlayerStatsEntity?> GetPlayerStatsByIdAsync(int playerId)
    {
        return await _context.PlayerStats.FindAsync(playerId);
    }

    public async Task<bool> CreatePlayerStats(AddPlayerStats createModel)
    {
        
        var playerStats = new PlayerStatsEntity
        {
            PlayerId = createModel.PlayerId,
            Goals = createModel.Goals,
            Assists = createModel.Assists,
            Saves = createModel.Saves
        };

        _context.PlayerStats.Add(playerStats);
        await _context.SaveChangesAsync();
        return true; 
    }
}
