using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data.Entities;

namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
    {
        public PLDbContext(DbContextOptions<PLDbContext> options)
            : base(options) {}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().ToTable("Users");
        }
    }
}