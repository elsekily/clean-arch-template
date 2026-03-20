using System.Data;

namespace Elsekily.Application.Common.Interfaces.Persistence.UnitOfWorks;

/// <summary>
/// Marker interface for the application's unit of work.
/// Implement this in Persistence to wrap SaveChangesAsync.
/// </summary>
public interface IAppUnitOfWork : IBaseUnitOfWork
{
    Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}