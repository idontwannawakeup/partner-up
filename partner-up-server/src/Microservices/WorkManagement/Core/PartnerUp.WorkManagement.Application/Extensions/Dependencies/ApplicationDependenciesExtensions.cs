using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PartnerUp.WorkManagement.Application.Common.Storages;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Storages;

namespace PartnerUp.WorkManagement.Application.Extensions.Dependencies;

public static class ApplicationDependenciesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient<IPhotoStorage, PhotoStorage>();
        return services;
    }
}
