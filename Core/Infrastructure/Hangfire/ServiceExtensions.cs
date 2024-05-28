using Hangfire;
using Hangfire.Storage.SQLite;
using Microsoft.Extensions.DependencyInjection;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Hangfire;

public static class ServiceExtensions
{
    public static IServiceCollection AddHangFire(this IServiceCollection services)
    {
        GlobalConfiguration.Configuration.UseSQLiteStorage();

        services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(nameOrConnectionString: SqlLiteDbContext.DbPath));
        
        services.AddHangfireServer();

        return services;
    }
}