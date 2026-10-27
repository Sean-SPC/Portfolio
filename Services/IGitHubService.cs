using Portfolio.Models;

namespace Portfolio.Services;

public interface IGitHubService
{
    Task<IEnumerable<Project>> GetRepositoriesAsync();
}