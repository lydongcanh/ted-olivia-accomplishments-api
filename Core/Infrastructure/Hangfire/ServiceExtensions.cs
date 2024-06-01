using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.Extensions.DependencyInjection;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Hangfire;

public static class ServiceExtensions
{
    public static IServiceCollection AddHangFire(this IServiceCollection services)
    {
        GlobalConfiguration.Configuration.UseSQLiteStorage();

        services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage());
        
        services.AddHangfireServer();

        return services;
    }
}