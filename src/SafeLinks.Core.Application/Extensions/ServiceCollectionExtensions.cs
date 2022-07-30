using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SafeLinks.Core.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
    {
        return services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}