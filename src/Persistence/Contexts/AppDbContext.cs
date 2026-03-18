using Elsekily.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Elsekily.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // TODO: add your DbSets here
    // public DbSet<MyEntity> MyEntities => Set<MyEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // TODO: apply entity configurations
        // builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // TODO: add auditing interceptor logic here if not using an EF interceptor
        return base.SaveChangesAsync(cancellationToken);
    }
}
