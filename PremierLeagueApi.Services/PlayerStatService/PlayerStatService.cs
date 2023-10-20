using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;

public class PlayerStatsService : IPlayerStatsService
{
    private readonly PLDbContext _context;

    public PlayerStatsService(PLDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerStats?> GetPlayerStatsByIdAsync(int playerStatsId)
    {
        return await _context.PlayerStats.FindAsync(playerStatsId);
    }

    public async Task<List<PlayerStats>> GetAllPlayerStatsAsync()
    {
        return await _context.PlayerStats.ToListAsync();
    }

    public async Task CreatePlayerStatsAsync(PlayerStats playerStats)
    {
        _context.PlayerStats.Add(playerStats);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerStatsAsync(PlayerStats playerStats)
    {
        _context.PlayerStats.Update(playerStats);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerStatsAsync(int playerStatsId)
    {
        var playerStats = await GetPlayerStatsByIdAsync(playerStatsId);
        if (playerStats != null)
        {
            _context.PlayerStats.Remove(playerStats);
            await _context.SaveChangesAsync();
        }
    }
}
