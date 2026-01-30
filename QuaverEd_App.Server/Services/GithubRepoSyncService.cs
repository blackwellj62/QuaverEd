using System.Net.Http;
using System.Threading.Tasks;

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
        var response = await _githubClient.GetAsync("/rate_limit");
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            return $"GitHub call failed. Status={(int)response.StatusCode} {response.StatusCode}. Body={body}";
        }
        return "GitHub call succeeded (rate_limit endpoint reachable).";
    }
}