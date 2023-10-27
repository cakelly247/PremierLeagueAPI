using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {

        public DbSet<TeamEntity> Teams { get; set; }        
        public DbSet<ManagerEntity> Managers { get; set; }
        public DbSet<PlayerStatsEntity> PlayerStats { get; set; } 
        public DbSet<PlayerEntity> Players { get; set; }
        public PLDbContext(DbContextOptions<PLDbContext> options)

            : base(options) { }
            
    }
}
