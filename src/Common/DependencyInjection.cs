namespace Microsoft.Extensions.DependencyInjection;

public static class CommonDependencyInjection
{
    /// <summary>
    /// Register all Common-layer services here.
    /// </summary>
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        // TODO: add common service registrations
        // Example: services.AddScoped<IUserService, UserService>();

        return services;
    }
}
