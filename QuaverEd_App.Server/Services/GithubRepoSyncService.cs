using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using QuaverEd_App.Server.DTOs;

namespace QuaverEd_App.Server.Services;

public class GithubRepoSyncService : IGithubRepoSyncService
{
    private readonly HttpClient _githubClient;
    public GithubRepoSyncService(IHttpClientFactory httpClientFactory)
    {
        _githubClient = httpClientFactory.CreateClient("github");
    }
    public async Task<string> SyncTopRepositoriesAsync()
    {
        var requestPath = "/search/repositories?q=language:C%23&sort=stars&order=desc&per_page=100";
        var response = await _githubClient.GetAsync(requestPath);
        if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                return $"GitHub search failed. Status={(int)response.StatusCode} {response.StatusCode}. Body={body}";
            }
        var json = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        var searchResponse = JsonSerializer.Deserialize<GitHubSearchResponseDto>(json, options);
        if (searchResponse == null)
         {
            return "Deserialization failed: searchResponse was null.";
        }

    return $"Deserialization succeeded. Items count: {searchResponse.Items.Count}";
    }
}
