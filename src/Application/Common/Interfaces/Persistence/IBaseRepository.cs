using Elsekily.Domain.Common;

namespace Elsekily.Application.Common.Interfaces.Persistence;

/// <summary>
/// Generic base repository interface. Extend this for feature-specific repositories.
/// </summary>
public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    Task AddRangeAsync(List<TEntity> entities);
    TEntity Delete(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
    TEntity Update(TEntity entity);
}
