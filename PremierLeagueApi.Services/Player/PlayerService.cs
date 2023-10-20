using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Models.Player;
using Microsoft.AspNetCore.Identity;

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
    }
}