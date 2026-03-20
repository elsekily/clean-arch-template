using Elsekily.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.AppDir.Interceptors;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace Persistence.Contexts.AppDir;

public class AppDbContext : DbContext
{
    private readonly AuditableEntityInterceptor _auditableInterceptor;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public AppDbContext(DbContextOptions<AppDbContext> options, AuditableEntityInterceptor auditableInterceptor) : base(options)
    {
        _auditableInterceptor = auditableInterceptor;
    }

    // TODO: add your DbSets here
    // public DbSet<MyEntity> MyEntities => Set<MyEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);

        // apply global configuration for datetime columns
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            if (typeof(BaseAuditableEntity).IsAssignableFrom(entity.ClrType))
            {
                builder.Entity(entity.ClrType)
                    .Property(nameof(BaseAuditableEntity.CreatedAt))
                    .IsRequired();

                builder.Entity(entity.ClrType)
                    .Property(nameof(BaseAuditableEntity.CreatedBy))
                    .IsRequired();
            }
        }

        var entities = builder.Model.GetEntityTypes()
        .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType));

        foreach (var entity in entities)
        {
            var method = typeof(ModelBuilder)
                .GetMethods()
                .First(m => m.Name == "Entity" && m.IsGenericMethod)
                .MakeGenericMethod(entity.ClrType);

            var entityBuilder = method.Invoke(builder, null);

            var parameter = Expression.Parameter(entity.ClrType, "e");
            var property = Expression.Property(parameter, nameof(ISoftDelete.IsDeleted));
            var condition = Expression.Equal(property, Expression.Constant(false));
            var lambda = Expression.Lambda(condition, parameter);

            entity.ClrType
                .GetMethod("HasQueryFilter")?
                .Invoke(entityBuilder, new object[] { lambda });
        }
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        var deletedEntries = ChangeTracker.Entries<ISoftDelete>()
                        .Where(e => e.State == EntityState.Deleted);

        foreach (var entry in deletedEntries)
        {
            entry.State = EntityState.Modified;
            entry.Entity.IsDeleted = true;
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
