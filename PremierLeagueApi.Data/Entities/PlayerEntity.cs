using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Data.Enums;

namespace PremierLeagueApi.Data.Entities
{
    public class PlayerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int JerseyNumber { get; set; }

        [Required]
        public Position Position;

        [Required]
        public string Country { get; set; } = string.Empty;

        [ForeignKey("Teams")]
        public int TeamId { get; set; }

        public virtual PlayerStats PlayerStats { get; set; } = null!;
    }
}