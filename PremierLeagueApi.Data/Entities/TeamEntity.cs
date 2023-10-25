using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data.Entities;

public class TeamEntity
{
    [Key]
    public int TeamId { get; set; }

    [Required, MaxLength(100)]
    public string TeamName {get; set;}

    [Required, MaxLength (100)]
    public string City {get; set;}

    public int Wins {get; set;} = 0;

    public int Losses {get; set;} = 0;
    
    public virtual List<PlayerEntity>? Players {get; set;}
}

