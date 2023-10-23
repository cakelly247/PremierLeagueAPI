using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PremierLeagueApi.Data.Entities;
using PremierLeagueApi.Data.Enums;

namespace PremierLeagueApi.Models.Player
{
    public class PlayerCreate
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int JerseyNumber { get; set; }

        [Required]
        public Position Position;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}