using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data.Entities;

public class PlayerStatsEntity
{
    [Key]
    public int PlayerId { get; set; } 

    [ForeignKey("PlayerId")]
    public PlayerEntity Player { get; set; } = new();

    public int Goals { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Saves { get; set; } = 0;
}
