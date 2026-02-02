using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuaverEd_App.Server.Data;
using QuaverEd_App.Server.DTOs;
using QuaverEd_App.Server.Services;

namespace QuaverEd_App.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoriesController : ControllerBase
    {
      private readonly IGithubRepoSyncService _syncService;
      private readonly AppDbContext _db;
      public RepositoriesController(IGithubRepoSyncService syncService, AppDbContext db)
        {
            _syncService = syncService;
            _db = db;
        }

        [HttpPost("sync")]
        public async Task<IActionResult> Sync()
        {
            var result = await _syncService.SyncTopRepositoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var repos = await _db.Repositories
                .AsNoTracking()
                .OrderByDescending(r => r.StarCount)
                .ToListAsync();

            return Ok(repos);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var repo = await _db.Repositories
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.RepositoryId == id);

            if (repo == null)
                return NotFound();

            return Ok(repo);
        }
    }
}