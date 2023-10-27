using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Models.PlayerStatsModel
{
    public class UpdatePlayerStats
    {
        [ForeignKey("Players")]
        public int PlayerId { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Saves { get; set; }
    }
}