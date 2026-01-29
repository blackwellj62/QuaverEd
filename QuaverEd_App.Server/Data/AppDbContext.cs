using Microsoft.EntityFrameworkCore;
using QuaverEd_App.Server.Models;

namespace QuaverEd_App.Server.Data;
    public class AppDbContext : DbContext
    {
        public DbSet<Repository> Repositories {get; set;}

    
        public AppDbContext(DbContextOptions<AppDbContext>options)
        :base(options)
    {
        
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Repository>(entity =>
            {
            entity.HasKey(r => r.RepositoryId);

            entity.Property(r => r.RepositoryId)
                .IsRequired();

            entity.Property(r => r.Name)
                .IsRequired();

            entity.Property(r => r.OwnerUsername)
                .IsRequired();

            entity.Property(r => r.HtmlUrl)
                .IsRequired();

            entity.Property(r => r.CreatedAt)
                .IsRequired();

            entity.Property(r => r.PushedAt)
                .IsRequired(false);

            entity.Property(r => r.Description)
                .IsRequired(false);

            entity.Property(r => r.StarCount)
                .IsRequired();
            });
        }
    }
    



