using SafeLinks.Core.Application.Extensions;
using SafeLinks.Core.Application.Interfaces.Repositories;
using SafeLinks.Core.Application.Interfaces.Services;
using SafeLinks.Infrastructure.Repositories;
using SafeLinks.Web.Client.Services;

namespace SafeLinks.Web.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWebClientServices(this IServiceCollection services)
    {
        return AddApplicationServices(services);
    }

    private static IServiceCollection AddApplicationServices(IServiceCollection services)
    {
        return services.AddTransient<IGuidService, GuidService>();
    }
}