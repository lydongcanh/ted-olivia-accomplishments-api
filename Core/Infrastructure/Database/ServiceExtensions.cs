using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;

public static class ServiceExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AccomplishmentsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("NeonDb"));
            options.UseSnakeCaseNamingConvention();
        });

        return services;
    }
}