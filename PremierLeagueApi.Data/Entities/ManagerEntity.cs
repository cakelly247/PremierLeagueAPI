using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data
{
    public class ManagerEntity
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [ForeignKey("Teams")]
        public int TeamId { get; set; }
    }
}
