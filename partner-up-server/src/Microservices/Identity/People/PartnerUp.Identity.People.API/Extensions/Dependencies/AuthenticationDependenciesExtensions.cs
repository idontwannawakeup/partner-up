using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PartnerUp.Identity.People.API.Extensions.Dependencies;

public static class AuthenticationDependenciesExtensions
{
    public static IServiceCollection AddPartnerUpAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.ApiName = "identity-api";
                        options.Authority = configuration["AuthenticationAuthorityUrl"];
                    });

        return services;
    }
}
