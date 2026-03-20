using Elsekily.Application.Common.Models;
using Elsekily.Application.Features.IsAlive.Models;

namespace Elsekily.Application.Features.IsAlive.Queries.GetIsAlive;

public interface IGetIsAliveQuery
{
    Task<Result<IsAliveResponse>> ExecuteAsync(CancellationToken cancellationToken = default);
}
