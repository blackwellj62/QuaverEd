using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using QuaverEd_App.Server.Data;
using QuaverEd_App.Server.Models;
using QuaverEd_App.Server.DTOs;

namespace QuaverEd_App.Server.Services;

public class GithubRepoSyncService : IGithubRepoSyncService
{
    private readonly HttpClient _githubClient;
    private readonly AppDbContext _db;
    public GithubRepoSyncService(IHttpClientFactory httpClientFactory, AppDbContext db)
    {
        _githubClient = httpClientFactory.CreateClient("github");
        _db = db;
    }
    public async Task<RepoSyncResultDto> SyncTopRepositoriesAsync()
    {
        var requestPath = "/search/repositories?q=language:C%23&sort=stars&order=desc&per_page=100";
        var response = await _githubClient.GetAsync(requestPath);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        var searchResponse = JsonSerializer.Deserialize<GitHubSearchResponseDto>(json, options);
        if (searchResponse == null)
        {
            throw new InvalidOperationException("Github deserialization returned null.");
        }
        var items = searchResponse.Items;
        var totalProcessed = items.Count;

        var incomingIds = items.Select(r => r.Id).ToList();

        var existingRepos = await _db.Repositories.Where(r => incomingIds.Contains(r.RepositoryId)).ToListAsync();

        var existingById = existingRepos.ToDictionary(r => r.RepositoryId);

        var inserted = 0;
        var updated = 0;
        foreach (var gh in items)
        {
            if (string.IsNullOrWhiteSpace(gh.Name))
            continue;

            if (gh.Owner == null || string.IsNullOrWhiteSpace(gh.Owner.Login))
            continue;

            if (string.IsNullOrWhiteSpace(gh.HtmlUrl))
            continue;

            if (existingById.TryGetValue(gh.Id, out var existing))
            {
                existing.Name = gh.Name;
                existing.OwnerUsername = gh.Owner.Login;
                existing.HtmlUrl = gh.HtmlUrl;
                existing.CreatedAt = gh.CreatedAt;
                existing.PushedAt = gh.PushedAt;
                existing.Description = gh.Description;
                existing.StarCount = gh.StargazersCount;

                updated++;
            }
            else
            {
                var entity = new Repository
                {
                    RepositoryId = gh.Id,
                    Name = gh.Name,
                    OwnerUsername = gh.Owner.Login,
                    HtmlUrl = gh.HtmlUrl,
                    CreatedAt = gh.CreatedAt,
                    PushedAt = gh.PushedAt,
                    Description = gh.Description,
                    StarCount = gh.StargazersCount
                };
                _db.Repositories.Add(entity);
                inserted++;
            }
        }
        await _db.SaveChangesAsync();
        return new RepoSyncResultDto
        {
            TotalProcessed = totalProcessed,
            Inserted = inserted,
            Updated = updated,
            TimestampUtc = DateTime.UtcNow

        };
    }
}
