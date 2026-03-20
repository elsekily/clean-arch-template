namespace Elsekily.Application.Common.Interfaces.Persistence;

public interface IBaseUnitOfWork : IDisposable
{
    Task CommitAsync(CancellationToken cancellationToken);
}