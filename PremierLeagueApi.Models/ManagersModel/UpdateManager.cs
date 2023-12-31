using System.ComponentModel.DataAnnotations;

namespace PremierLeagueApi.Models.ManagersModel
{
    public class UpdateManager
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        public int TeamId { get; set; }
    }
}
