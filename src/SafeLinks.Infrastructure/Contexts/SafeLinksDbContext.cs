using Microsoft.EntityFrameworkCore;
using SafeLinks.Core.Domain.Contracts;
using SafeLinks.Core.Domain.Entities;

namespace SafeLinks.Infrastructure.Contexts;

public class SafeLinksDbContext : DbContext
{
    public DbSet<SafetyAnalysis> SafetyAnalyses { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Shortcut> Shortcuts { get; set; }
    
    public SafeLinksDbContext(DbContextOptions options) : base(options) { }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.Now;
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.Now;
                    break;
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

}