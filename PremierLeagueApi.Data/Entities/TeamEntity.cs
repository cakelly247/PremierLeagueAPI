using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data.Entities;

public class TeamEntity
{
    [Key]
    public int TeamId { get; set; }

    [Required, MaxLength(100)]
    public string TeamName {get; set;} = string.Empty;

    [Required, MaxLength (100)]
    public string City {get; set;} = string.Empty;

    public int Wins {get; set;} = 0;

    public int Losses {get; set;} = 0;
    
    [ForeignKey("Managers")]
    public int ManagerId { get; set; } = 1;
    
    public List<PlayerEntity>? Players {get; set;}
}

