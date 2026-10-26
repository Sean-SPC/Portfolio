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
                    ProjectName = "Project 1",
                    LastUpdated = DateTime.Parse("2025-10-20"),
                    Language = "C#"
                },
                new Project
                {
                    ProjectName = "Project 2",
                    LastUpdated = DateTime.Parse("2025-10-25"),
                    Language = "Java"
                }
            );
            context.SaveChanges();
        }
    }
}