using System.ComponentModel.DataAnnotations;

public class PlayerStats
{
    [Key]
    public int PlayerStatsId { get; set; }

    [Required]
    public int Goals { get; set; }

    [Required]
    public int Assists { get; set; }

    [Required]
    public int Saves { get; set; }

    public int PlayerId { get; set; }

    
}
