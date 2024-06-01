using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;

/// <summary>
/// TODO: Add interface
/// </summary>
public class AccomplishmentsDbContext : DbContext
{
    public DbSet<Accomplishment> Accomplishments { get; set; }

    public AccomplishmentsDbContext(DbContextOptions<AccomplishmentsDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    public override int SaveChanges()
    {
        SetBaseEntityProperties();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseEntityProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    private void SetBaseEntityProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.Id = Guid.NewGuid().ToString("N");
                entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
            }
        }
    }
}