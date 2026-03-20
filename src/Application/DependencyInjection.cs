using Elsekily.Application.Features.IsAlive.Queries.GetIsAlive;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    /// <summary>
    /// Register all Application services here.
    /// Pattern: services.AddScoped&lt;IMyQuery, MyQuery&gt;();
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGetIsAliveQuery, GetIsAliveQuery>();

        return services;
    }
}
