using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;
using PartnerUp.Identity.People.BusinessLogic.Services;

namespace PartnerUp.Identity.People.BusinessLogic.Extensions.Dependencies;

public static class ServicesDependenciesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPhotosService, PhotosService>();
        services.AddTransient<IUsersService, UsersService>();
        return services;
    }
}
