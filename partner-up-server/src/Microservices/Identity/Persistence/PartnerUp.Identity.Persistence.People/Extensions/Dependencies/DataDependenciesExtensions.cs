using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Identity.Persistence.People.Data;
using PartnerUp.Identity.Persistence.People.Data.Repositories;
using PartnerUp.Identity.Persistence.People.Interfaces.Data;
using PartnerUp.Identity.Persistence.People.Interfaces.Data.Repositories;

namespace PartnerUp.Identity.Persistence.People.Extensions.Dependencies;

public static class DataDependenciesExtensions
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
