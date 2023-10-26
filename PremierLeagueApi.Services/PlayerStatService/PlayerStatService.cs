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

    public async Task<bool> UpdatePlayerStatsAsync( UpdatePlayerStats model)
    {
        var player = await _context.PlayerStats.FindAsync(model.PlayerId);

        if (player == null)
        {
            return false;
        }

        model.Goals = player.Goals;
        model.Assists = player.Assists;
        model.Saves = player.Saves;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<PlayerStatsEntity?> GetPlayerStatsByIdAsync(int playerId)
    {
        return await _context.PlayerStats.FindAsync(playerId);
    }

}
