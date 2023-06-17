using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PartnerUp.Social.BusinessLogic.Common.Validation;

namespace PartnerUp.Social.BusinessLogic.Extensions.Dependencies;

public static class ValidationDependenciesExtensions
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();
        services.AddControllers()
                .AddFluentValidation(configuration =>
                    configuration.RegisterValidatorsFromAssemblyContaining<ValidationDependencyInjection>());

        return services;
    }
}
