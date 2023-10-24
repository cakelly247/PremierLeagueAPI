using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Player;
using PremierLeagueApi.Models.Teams;

namespace PremierLeagueApi.Services.Player
{
    public class PlayerService : IPlayerService
    {
        private readonly PLDbContext _context;

        public PlayerService(PLDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlayerAsync(PlayerCreate model)
        {
            if (model is null)
            {
                return false;
            }

            PlayerEntity entity = new()
            {
                Name = model.Name,
                JerseyNumber = model.JerseyNumber,
                Position = model.Position,
                Country = model.Country
            };

            await _context.AddAsync(entity);
            var success = await _context.SaveChangesAsync();
            
            return success != 0 ? true : false;
        }

        public async Task<PlayerEntity?> GetPlayerByIdAsync(int playerId)
        {
            return await _context.Players.FindAsync(playerId);
        }

        public async Task<List<PlayerEntity>> GetAllPlayersAsync()
        {
            return await _context.Players.ToListAsync();
        }


        public async Task<bool> UpdatePlayerAsync(PlayerUpdate model)
        {
            var player = await _context.Players.FindAsync(model.Id);
            if (player is null)
            {
                return false;
            }

            player.Name = model.Name;
            player.JerseyNumber = model.JerseyNumber;
            player.Position = model.Position;
            player.Country = model.Country;
            player.TeamId = model.TeamId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateTeamPlayerAsync(UpdateTeamPlayer model)
        {
            var player = await _context.Players.FindAsync(model.Id);
            if (player is null)
            {
                return false;
            }

            player.TeamId = model.TeamId;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            var player = await _context.Players.FindAsync(playerId);
            if (player is null)
            {
                return false;
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}