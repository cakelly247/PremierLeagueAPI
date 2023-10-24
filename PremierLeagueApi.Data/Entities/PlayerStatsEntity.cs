using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PremierLeagueApi.Data.Entities;

public class PlayerStatsEntity
{
    [Key]
    [ForeignKey("Players")]
    public int PlayerId { get; set; } 

    public int Goals { get; set; } = 0;

    public int Assists { get; set; } = 0;

    public int Saves { get; set; } = 0;
}
