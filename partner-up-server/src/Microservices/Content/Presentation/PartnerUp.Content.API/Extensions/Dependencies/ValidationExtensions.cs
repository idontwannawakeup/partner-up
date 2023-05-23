using FluentValidation;
using FluentValidation.AspNetCore;
using PartnerUp.Content.Application.Common.Validation;

namespace PartnerUp.Content.API.Extensions.Dependencies;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
        services.AddControllers()
                .AddFluentValidation(configuration =>
                {
                    configuration.RegisterValidatorsFromAssemblyContaining<ValidationDependencyInjection>();
                });

        return services;
    }
}
