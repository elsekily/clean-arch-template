using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddHttpClients(services, configuration);
        AddBackgroundJobs(services);

        // TODO: add infrastructure service registrations
        // services.AddSingleton<ICacheService, InMemoryCacheService>();
        // services.AddScoped<IEmailService, SmtpEmailService>();

        return services;
    }

    private static void AddHttpClients(IServiceCollection services, IConfiguration configuration)
    {
        // TODO: configure named HttpClients
        // services.AddHttpClient("MyClient", client =>
        // {
        //     client.BaseAddress = new Uri(configuration["ExternalApi:BaseUrl"]!);
        // });
    }

    private static void AddBackgroundJobs(IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            // TODO: register Quartz jobs here
            // var jobKey = new JobKey(nameof(MyJob));
            // q.AddJob<MyJob>(opts => opts.WithIdentity(jobKey));
            // q.AddTrigger(opts => opts
            //     .ForJob(jobKey)
            //     .WithIdentity("MyJob-trigger")
            //     .WithCronSchedule("0 0/5 * * * ?"));
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}
