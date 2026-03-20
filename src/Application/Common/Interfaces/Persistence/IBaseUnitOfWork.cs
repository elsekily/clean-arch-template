namespace Elsekily.Application.Common.Interfaces.Persistence;

public interface IBaseUnitOfWork : IDisposable
{
    Task<bool> CanConnectAsync(CancellationToken cancellationToken = default);
    Task CommitAsync(CancellationToken cancellationToken);
}