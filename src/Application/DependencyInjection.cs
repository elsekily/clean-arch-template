namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    /// <summary>
    /// Register all Application services here.
    /// Pattern: services.AddScoped&lt;IMyQuery, MyQuery&gt;();
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // TODO: register your Commands and Queries here
        // Example:
        // services.AddScoped<IGetItemsQuery, GetItemsQuery>();
        // services.AddScoped<ICreateItemCommand, CreateItemCommand>();

        return services;
    }
}
