using System.ComponentModel.DataAnnotations;
using PremierLeagueApi.Data.Enums;

namespace PremierLeagueApi.Models.Player
{
    public class PlayerUpdate
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int JerseyNumber { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        public int TeamId { get; set; }
    }
}