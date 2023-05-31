using MassTransit;
using PartnerUp.Content.API.Consumers;
using PartnerUp.Content.Application.Common.Settings;

namespace PartnerUp.Content.API.Extensions.Dependencies;

public static class PresentationExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton(configuration
                              .GetSection(nameof(ServicesSettings))
                              .Get<ServicesSettings>());

        services.AddValidation();
        services.AddAuthenticationWithJwtBearer(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddRedis(configuration);

        services.AddMassTransit(massTransitConfiguration =>
        {
            massTransitConfiguration.AddConsumer<ProjectAddedToRecentEventConsumer>();
            massTransitConfiguration.AddConsumer<TeamAddedToRecentEventConsumer>();
            massTransitConfiguration.AddConsumer<TicketAddedToRecentEventConsumer>();

            massTransitConfiguration.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(configuration["EventBusSettings:HostAddress"]);
                configurator.ReceiveEndpoint(
                    "content-recent-project",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<ProjectAddedToRecentEventConsumer>(
                            context);
                    });

                configurator.ReceiveEndpoint(
                    "content-recent-team",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<TeamAddedToRecentEventConsumer>(
                            context);
                    });

                configurator.ReceiveEndpoint(
                    "content-recent-ticket",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<TicketAddedToRecentEventConsumer>(
                            context);
                    });
            });
        });

        return services;
    }
}
