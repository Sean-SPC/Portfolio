using System.Net.Http.Headers;
using System.Net.Http.Json;
using Portfolio.Models;

namespace Portfolio.Services;

public class GitHubService(HttpClient httpClient) : IGitHubService
{
    public async Task<IEnumerable<Project>> GetRepositoriesAsync()
    {
        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "user/repos?visibility=all&per_page=100");

        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

        using var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var repositories = await response.Content.ReadFromJsonAsync<List<GitHubRepoDto>>();

        return (repositories ?? [])
            .Select(repo => new Project
            {
                ID = repo.Id.ToString(),
                Name = repo.Name,
                HTML_URL = repo.HtmlUrl,
                Language = string.IsNullOrWhiteSpace(repo.Language) ? "Not specified" : repo.Language
            });
    }
}