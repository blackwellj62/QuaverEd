using QuaverEd_App.Server.DTOs;

namespace QuaverEd_App.Server.Services;

public interface IGithubRepoSyncService
{
    Task<RepoSyncResultDto> SyncTopRepositoriesAsync();
}