using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data
{
    public class ManagerEntity
    {
        [Key]
        public int ManagerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [ForeignKey("Teams")]
        public int TeamId { get; set; } = 1;
    }
}
