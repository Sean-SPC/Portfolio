using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Services;

public class ProjectSyncService(
    IGitHubService gitHubService,
    PortfolioContext dbContext)
{
    public async Task SyncAsync()
    {
        var githubProjects = await gitHubService.GetRepositoriesAsync();

        var existingProjects = await dbContext.Projects
            .ToDictionaryAsync(p => p.ID);

        foreach (var githubProject in githubProjects)
        {
            if (existingProjects.TryGetValue(githubProject.ID, out var project))
            {
                // Update an existing database record
                project.Name = githubProject.Name;
                project.HTML_URL = githubProject.HTML_URL;
                project.Language = githubProject.Language;
            }
            else
            {
                // Insert a new repository
                dbContext.Projects.Add(new Project
                {
                    ID = githubProject.ID,
                    Name = githubProject.Name,
                    HTML_URL = githubProject.HTML_URL,
                    Language = githubProject.Language
                });
            }
        }

        await dbContext.SaveChangesAsync();
    }
}