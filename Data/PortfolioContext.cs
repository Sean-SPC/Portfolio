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

        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<Project> Project { get => Projects; set => Projects = value; }
    }
}
