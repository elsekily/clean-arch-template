using Elsekily.Application.Common.Interfaces.Persistence.Repositories;
using Elsekily.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.AppDir;

namespace Elsekily.Persistence.Repositories;

/// <summary>
/// Generic base repository. Inherit and add entity-specific methods.
/// Example: public class ItemRepository : BaseRepository&lt;Item&gt;, IItemRepository
/// </summary>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entry.Entity;
    }

    public async Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public TEntity Delete(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        return entry.Entity;
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public TEntity Update(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }
}
