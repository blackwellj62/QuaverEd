namespace QuaverEd_App.Server.Services;

public class GithubRepoSyncService : IGithubRepoSyncService
{
    public Task<string> SyncTopRepositoriesAsync()
    {
        return Task.FromResult("Sync endpoint wired correctly, not implemented yet");
    }
}