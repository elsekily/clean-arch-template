using Elsekily.Application.Common.Interfaces.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Contexts.AppDir;
using Persistence.UnitOfWorks;

namespace Microsoft.Extensions.DependencyInjection;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        AddDatabases(services, configuration);
        AddRepositories(services);
        AddUnitOfWorks(services);

        return services;
    }
    private static void AddRepositories(IServiceCollection services)
    {
        // TODO: register your repositories here
        // services.AddScoped<IItemRepository, ItemRepository>();
    }
    private static void AddDatabases(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("App")));
    }

    private static void AddUnitOfWorks(IServiceCollection services)
    {
        services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
    }
}
