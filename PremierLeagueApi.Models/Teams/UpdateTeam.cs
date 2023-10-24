namespace PremierLeagueApi.Models.Teams;

public class UpdateManager
{
    public int TeamId { get; set; }

    [Required, MaxLength(100)]
    public string TeamName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string City { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int Wins { get; set; }

    [Range(0, int.MaxValue)]
    public int Losses { get; set; }

    public List<PlayerEntity>? Players { get; set; }
}