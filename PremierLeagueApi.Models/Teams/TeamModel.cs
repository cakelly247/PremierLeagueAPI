using System.ComponentModel.DataAnnotations;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Models.Teams;

public class TeamModel
{
    [Required]
    public string TeamName {get; set;} = string.Empty;

    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Wins {get; set;}

    [Range(0, int.MaxValue)]
    public int Losses {get; set;}

    public List<PlayerEntity>? Players {get; set;}
}