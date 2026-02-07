using PartnerUp.WebClient.Authentication;
using PartnerUp.WebClient.Extensions;
using PartnerUp.WebClient.Interfaces;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Services;

public class RecommendationsService : IRecommendationsService
{
    private readonly ApiHttpClient _httpClient;

    public RecommendationsService(HttpClient httpClient, ApiAuthenticationStateProvider state)
    {
        _httpClient = new ApiHttpClientBuilder(httpClient)
            .AddAuthorization(state)
            .Build();
    }

    public async Task<RecommendationViewModel> RecommendAsync(Guid teamId)
    {
        return await _httpClient.GetAsync<RecommendationViewModel>($"{teamId}");
    }

    public async Task RankAsync(Guid eventId, int score)
    {
        await _httpClient.PostAsync($"{eventId}/{score}");
    }
}
