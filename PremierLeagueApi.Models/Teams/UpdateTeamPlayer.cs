using System.ComponentModel.DataAnnotations;

namespace PremierLeagueApi.Models.Teams;

public class UpdateTeamPlayer
{
    public int TeamId { get; set; }
    public int Id { get; set; }
}