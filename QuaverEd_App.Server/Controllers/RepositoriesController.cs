using Microsoft.AspNetCore.Mvc;
using QuaverEd_App.Server.DTOs;
using QuaverEd_App.Server.Services;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoriesController : ControllerBase
    {
      private readonly IGithubRepoSyncService _syncService;
      public RepositoriesController(IGithubRepoSyncService syncService)
        {
            _syncService = syncService;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> Sync()
        {
            var result = await _syncService.SyncTopRepositoriesAsync();
            return Ok(result);
        }
    }
}