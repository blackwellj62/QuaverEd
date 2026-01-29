namespace QuaverEd_App.Server.Services;

public interface IGithubRepoSyncService
{
    Task<string> SyncTopRepositoriesAsync();
}