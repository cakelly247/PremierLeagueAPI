namespace PremierLeagueApi.Models.PlayerStatsModel
{
    public class PlayerStatsDto
    {
        public int PlayerStatsId { get; set; }

        public int Goals { get; set; }

        public int Assists { get; set; }

        public int Saves { get; set; }

        public int PlayerId { get; set; }
    }
}
