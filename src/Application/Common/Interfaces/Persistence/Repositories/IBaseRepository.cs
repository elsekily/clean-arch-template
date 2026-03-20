using Elsekily.Domain.Common;

namespace Elsekily.Application.Common.Interfaces.Persistence.Repositories;

/// <summary>
/// Generic base repository interface. Extend this for feature-specific repositories.
/// </summary>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    TEntity Delete(TEntity entity);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    TEntity Update(TEntity entity);
}
