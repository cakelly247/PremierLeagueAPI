using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Data.Enums;

namespace PremierLeagueApi.Models.Player
{
    public class PlayerUpdate
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int JerseyNumber { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Teams")]
        public int TeamId { get; set; }
    }
}