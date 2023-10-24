using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PremierLeagueApi.Data.Enums;

namespace PremierLeagueApi.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(2)]
        public int JerseyNumber { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public string Country { get; set; } = string.Empty;

        [ForeignKey("Teams")]
        public int TeamId { get; set; } = 1;

        public PlayerStatsEntity PlayerStats { get; set; } = null!;
    }
}