using System.ComponentModel.DataAnnotations;

namespace PremierLeagueApi.Models.Teams;

public class UpdateTeamManager
{

    public int TeamId { get; set; }

    public int ManagerId { get; set; }
    
}