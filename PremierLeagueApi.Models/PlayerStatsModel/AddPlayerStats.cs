using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Models.PlayerStatsModel
{
    public class AddPlayerStats
    {
        [ForeignKey("Players")]
        public int PlayerId { get; set; }

        public int Goals { get; set; } = 0;

        public int Assists { get; set; } = 0;

        public int Saves { get; set; } = 0;
    }
}
