using System.ComponentModel.DataAnnotations;

namespace PremierLeagueApi.Models.Teams;

public class CreateTeam
{
    public int TeamId { get; set; }

    [MaxLength(100)]
    public string TeamName {get; set;} = string.Empty;

    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    public int Wins {get; set;} = 0;

    public int Losses {get; set;} = 0;

    public int ManagerId { get; set; } = 1;
}