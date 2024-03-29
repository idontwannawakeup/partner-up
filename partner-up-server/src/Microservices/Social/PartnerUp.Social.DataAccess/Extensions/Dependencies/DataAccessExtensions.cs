using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerUp.Social.DataAccess.Extensions.Dependencies;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddData();
        services.AddSeeding();
        return services;
    }
}
