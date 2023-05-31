using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

    public static IServiceCollection AddAuthenticationWithJwtBearer(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("JwtSecurityKeyJwtSecurityKeyJwtSecurityKey")),
                    ClockSkew = TimeSpan.Zero,
                };
            });

        return services;
    }
}
