using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerUp.Content.Application.Extensions.Dependencies;

public static class ApplicationDependenciesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
