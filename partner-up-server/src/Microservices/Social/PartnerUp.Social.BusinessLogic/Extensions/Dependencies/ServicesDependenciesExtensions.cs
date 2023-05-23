using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Social.BusinessLogic.Interfaces.Services;
using PartnerUp.Social.BusinessLogic.Services;

namespace PartnerUp.Social.BusinessLogic.Extensions.Dependencies;

public static class ServicesDependenciesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IFriendsService, FriendsService>();
        services.AddTransient<IRatingsService, RatingsService>();
        return services;
    }
}
