using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;

public class PlayerStatsService : IPlayerStatsService
{
    private readonly PLDbContext _context;

    public PlayerStatsService(PLDbContext context)
    {
        _context = context;
    }

    public async Task<PlayerStatsEntity?> GetPlayerStatsByIdAsync(int playerId)
    {
        return await _context.PlayerStats.FindAsync(playerId);
    }

    public async Task<List<PlayerStatsEntity>> GetAllPlayerStatsAsync()
    {
        return await _context.PlayerStats.ToListAsync();
    }

    public async Task CreatePlayerStatsAsync(PlayerStatsEntity playerStats)
    {
        _context.PlayerStats.Add(playerStats);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlayerStatsAsync(PlayerStatsEntity playerStats)
    {
        _context.PlayerStats.Update(playerStats);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePlayerStatsAsync(int playerId)
    {
        var playerStats = await GetPlayerStatsByIdAsync(playerId);
        if (playerStats != null)
        {
            _context.PlayerStats.Remove(playerStats);
            await _context.SaveChangesAsync();
        }
    }
}
