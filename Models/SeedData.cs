using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data;
using System;
using System.Linq;

namespace Portfolio.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PortfolioContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PortfolioContext>>()))
        {
            // Ensure database directory exists and apply pending migrations
            Directory.CreateDirectory("Database");
            context.Database.Migrate();

            // Look for any project.
            if (context.Project.Any())
            {
                return;   // DB has been seeded
            }
            context.Project.AddRange(
                new Project
                {
                    ID = "1",
                    Name = "Portfolio",
                    HTML_URL = "https://github.com/Sean-SPC/Portfolio",
                    Language = "C#"
                },
                new Project
                {
                    ID = "2",
                    Name = "Sample-Project",
                    HTML_URL = "https://github.com",
                    Language = "JavaScript"
                }
            );
            context.SaveChanges();
        }
    }
}