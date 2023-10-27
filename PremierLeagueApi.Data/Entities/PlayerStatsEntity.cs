using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data.Entities;

public class PlayerStatsEntity
{
    [Key, ForeignKey("Player")]
    public int PlayerId { get; set; } 

    public virtual PlayerEntity Player { get; set; }

    public int Goals { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Saves { get; set; } = 0;
}
