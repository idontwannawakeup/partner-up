using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PartnerUp.Content.API.Extensions.Dependencies;

public static class AuthenticationExtensions
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
                        options.ApiName = "content-api";
                        options.Authority = configuration["AuthenticationAuthorityUrl"];
                    });

        return services;
    }
}
