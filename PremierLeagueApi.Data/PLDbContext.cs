using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeagueApi.Data;

namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext
    {
        public DbSet<Manager> Managers { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; } 

        public PLDbContext(DbContextOptions<PLDbContext> options)
            : base(options) { }

       
    }
}
