using FluentValidation;
using FluentValidation.AspNetCore;
using PartnerUp.WorkManagement.Application.Common.Validation;

namespace PartnerUp.WorkManagement.API.Extensions.Dependencies;

public static class ValidationDependenciesExtensions
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
