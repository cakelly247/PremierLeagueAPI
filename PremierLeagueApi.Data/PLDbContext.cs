using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;
using PremierLeagueApi.Data.Entities;


namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; } 

        public PLDbContext(DbContextOptions<PLDbContext> options)

            : base(options) { }

       

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().ToTable("Users");
        }

    }
}
