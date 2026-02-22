using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        public PortfolioContext (DbContextOptions<PortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Project { get; set; } = default!;
    }
}
