using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Models.Player;

namespace PremierLeagueApi.Services.Player
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
    }
}