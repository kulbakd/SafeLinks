using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Core.Application.Interfaces.Services;
using SafeLinks.Infrastructure.Contexts;
using SafeLinks.Infrastructure.Repositories;

namespace SafeLinks.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        if (isDevelopment)
        {
            RegisterDevelopmentOnlyServices(services, configuration);
        }
        else
        {
            RegisterProductionOnlyServices(services);
        }

        return services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }

    private static IServiceCollection RegisterDevelopmentOnlyServices(IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<SafeLinksDbContext>(options => options
                .UseSqlite(configuration.GetConnectionString("DefaultConnection")));
    }
    
    private static IServiceCollection RegisterProductionOnlyServices(IServiceCollection services)
    {
        return services;
    }
}