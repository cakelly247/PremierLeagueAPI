using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PremierLeagueApi.Data
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public int TeamId { get; set; }

        
    }
}
