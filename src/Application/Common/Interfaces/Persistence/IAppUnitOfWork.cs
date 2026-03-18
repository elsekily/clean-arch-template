namespace Elsekily.Application.Common.Interfaces.Persistence;

/// <summary>
/// Marker interface for the application's unit of work.
/// Implement this in Persistence to wrap SaveChangesAsync.
/// </summary>
public interface IAppUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
