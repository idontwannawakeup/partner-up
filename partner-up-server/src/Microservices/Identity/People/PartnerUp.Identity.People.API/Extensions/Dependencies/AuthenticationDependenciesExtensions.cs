using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PartnerUp.Identity.People.BusinessLogic.Common.Factories;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Configurations;
using PartnerUp.Identity.People.BusinessLogic.Interfaces;

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

        services.AddTransient<JwtTokenConfiguration>();
        services.AddTransient<IJwtSecurityTokenFactory, JwtSecurityTokenFactory>();

        return services;
    }
}
