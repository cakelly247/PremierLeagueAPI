using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;

namespace PremierLeagueApi.Models
{
    public class UpdateManager
    {
        public int ManagerId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string Country { get; set; }

        public int TeamId { get; set; }
    }
}
