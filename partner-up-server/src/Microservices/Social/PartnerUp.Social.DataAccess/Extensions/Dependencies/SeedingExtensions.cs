using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Social.DataAccess.Data.Seeders;
using PartnerUp.Social.DataAccess.Interfaces.Data.Seeders;

namespace PartnerUp.Social.DataAccess.Extensions.Dependencies;

public static class SeedingExtensions
{
    public static IServiceCollection AddSeeding(this IServiceCollection services)
    {
        services.AddTransient<IRatingSeeder, RatingSeeder>();
        services.AddTransient<IUserProfileSeeder, UserProfileSeeder>();
        return services;
    }
}
