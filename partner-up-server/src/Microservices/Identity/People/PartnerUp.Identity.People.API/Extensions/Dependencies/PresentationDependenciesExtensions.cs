using MassTransit;

namespace PartnerUp.Identity.People.API.Extensions.Dependencies;

public static class PresentationDependenciesExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMassTransit(massTransitConfiguration =>
        {
            massTransitConfiguration.UsingRabbitMq((_, configurator) =>
            {
                configurator.Host(configuration["EventBusSettings:HostAddress"]);
            });
        });

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddPartnerUpAuthentication(configuration);
        services.AddPartnerUpSwagger();
        return services;
    }
}
