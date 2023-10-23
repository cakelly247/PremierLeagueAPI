using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {

        public DbSet<TeamEntity> Teams { get; set; }        
        public DbSet<ManagerEntity> Managers { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; } 
        public DbSet<PlayerEntity> Players { get; set; }
        public PLDbContext(DbContextOptions<PLDbContext> options)

            : base(options) { }
            

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().ToTable("Users");
        }
    }
}
