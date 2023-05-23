using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Social.DataAccess.Data.Entities;
using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;

namespace PartnerUp.Social.DataAccess.Extensions.Dependencies;

public static class FilterExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<Rating>, FilterFactory<Rating>>();
        return services;
    }
}
