using Elsekily.Application.Common.Interfaces.Persistence.UnitOfWorks;
using Elsekily.Application.Common.Models;
using Elsekily.Application.Features.IsAlive.Models;

namespace Elsekily.Application.Features.IsAlive.Queries.GetIsAlive;

public class GetIsAliveQuery(IAppUnitOfWork unitOfWork) : IGetIsAliveQuery
{
    public async Task<Result<IsAliveResponse>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        var canConnect = await unitOfWork.CanConnectAsync(cancellationToken);

        var response = new IsAliveResponse
        {
            Time = DateTime.Now,
            Status = canConnect ? IsAliveStatus.CompletelyAlive.ToString() : IsAliveStatus.Degraded.ToString()
        };

        return Result<IsAliveResponse>.Success(response);
    }
}
