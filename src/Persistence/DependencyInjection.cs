using Elsekily.Application.Common.Interfaces.Persistence;
using Elsekily.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddDatabases(services, configuration);
        AddRepositories(services);
        AddUnitOfWorks(services);

        return services;
    }

    private static void AddDatabases(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Elsekily.Persistence.Contexts.AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Default")));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        // TODO: register your repositories here
        // services.AddScoped<IItemRepository, ItemRepository>();
    }

    private static void AddUnitOfWorks(IServiceCollection services)
    {
        // TODO: register your unit of work
        // services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
    }
}
