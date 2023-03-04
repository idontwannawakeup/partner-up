using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;

namespace PartnerUp.Identity.Persistence.People.Extensions.Dependencies;

public static class FiltersDependenciesExtensions
{
    public static IServiceCollection AddFilterFactories(this IServiceCollection services)
    {
        services.AddTransient<IFilterCriteriaFactory, FilterCriteriaFactory>();
        services.AddTransient<IFilterFactory<User>, FilterFactory<User>>();
        return services;
    }
}
