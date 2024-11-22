using PartnerUp.WebClient.Authentication;
using PartnerUp.WebClient.Extensions;
using PartnerUp.WebClient.Interfaces;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Services;

public class RecommendationService : IRecommendationsService
{
    private readonly ApiHttpClient _httpClient;

    public async Task<IEnumerable<RecommendedUserViewModel>> RecommendCandidates(JobDescriptionViewModel jobDescription)
    {
        var candidates = await _httpClient.PostAsync<JobDescriptionViewModel, IEnumerable<RecommendedUserViewModel>>("predict-candidate", jobDescription);
        return candidates;
    }

    public RecommendationService(HttpClient httpClient, ApiAuthenticationStateProvider state) =>
        _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(state).Build();
}
