using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PremierLeagueApi.Data.Entities
{
    public class ManagerEntity
    {
        [Key]
        public int ManagerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }

        public virtual TeamEntity? Team { get; set; }
    }
}
