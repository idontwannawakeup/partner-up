using MassTransit;
using PartnerUp.WorkManagement.API.Consumers;

namespace PartnerUp.WorkManagement.API.Extensions.Dependencies;

public static class PresentationDependenciesExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddGrpc();
        services.AddValidation();
        services.AddPartnerUpAuthentication(configuration);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddMassTransit(massTransitConfiguration =>
        {
            massTransitConfiguration.AddConsumer<UserCreatedEventConsumer>();
            massTransitConfiguration.AddConsumer<UserChangedEventConsumer>();
            massTransitConfiguration.AddConsumer<UserAvatarChangedEventConsumer>();

            massTransitConfiguration.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(configuration["EventBusSettings:HostAddress"]);
                configurator.ReceiveEndpoint(
                    "work-management-user-created",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserCreatedEventConsumer>(context);
                    });

                configurator.ReceiveEndpoint(
                    "work-management-user-changed",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserChangedEventConsumer>(context);
                    });

                configurator.ReceiveEndpoint(
                    "work-management-user-avatar-changed",
                    endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumer<UserAvatarChangedEventConsumer>(context);
                    });
            });
        });

        return services;
    }
}
