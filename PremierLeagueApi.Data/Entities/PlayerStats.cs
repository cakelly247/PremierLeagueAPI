using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PlayerStats
{
    [Key]
    [ForeignKey("Players")]
    public int PlayerStatsId { get; set; }

    [Required]
    public int Goals { get; set; }

    [Required]
    public int Assists { get; set; }

    [Required]
    public int Saves { get; set; }

    // [ForeignKey("Players")]
    // public int PlayerId { get; set; }
}
