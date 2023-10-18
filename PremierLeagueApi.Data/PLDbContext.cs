using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PremierLeagueApi.Data
{
    public class PLDbContext : IdentityDbContext
    {
        public PLDbContext(DbContextOptions<PLDbContext> options)
            : base(options) {}
    }
}