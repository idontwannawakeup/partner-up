using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Social.DataAccess.Data;
using PartnerUp.Social.DataAccess.Data.Repositories;
using PartnerUp.Social.DataAccess.Interfaces.Data;
using PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;

namespace PartnerUp.Social.DataAccess.Extensions.Dependencies;

public static class DataExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IFriendsRepository, FriendsRepository>();
        services.AddTransient<IRatingsRepository, RatingsRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
