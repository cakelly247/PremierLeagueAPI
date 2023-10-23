using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data.Entities;

public class PlayerStats
{
    [ForeignKey("Players")]
    public int PlayerStatsId { get; set; }

    public int Goals { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Saves { get; set; } = 0;
}
