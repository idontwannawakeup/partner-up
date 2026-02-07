using Microsoft.Azure.CognitiveServices.Personalizer;
using PartnerUp.Recommendations.API.Clients;
using PartnerUp.Recommendations.API.Common;
using PartnerUp.Recommendations.API.Services;

namespace PartnerUp.Recommendations.API.Extensions.Dependencies;

public static class PresentationDependenciesExtensions
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPartnerUpAuthentication(configuration);
        services.AddMvc();
        
        services.AddTransient<PersonalizerClient>(_ => new PersonalizerClient(
            new ApiKeyServiceClientCredentials(configuration["Personalizer:ApiKey"]))
        {
            Endpoint = configuration["Personalizer:ServiceEndpoint"],
        });

        services.AddHttpClient<WorkManagementHttpClient>(httpClient =>
        {
            httpClient.BaseAddress = new($"{configuration["WorkManagementServiceUrl"]}/");
        });

        services.AddHttpClient<IdentityPeopleHttpClient>(httpClient =>
        {
            httpClient.BaseAddress = new($"{configuration["IdentityPeopleServiceUrl"]}/");
        });

        services.AddScoped<IPersonalizerRecommendationsClient, RecommendationsClient>();
        services.AddScoped<IRecommendationsService, PersonalizerRecommendationsService>(); 

        return services;
    }
}
