using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerStats
{
    [ForeignKey("Players")]
    public int PlayerStatsId { get; set; }

    public int Goals { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Saves { get; set; } = 0;

    // [ForeignKey("Players")]
    // public int PlayerId { get; set; }
}
