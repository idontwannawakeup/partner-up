using Microsoft.Azure.CognitiveServices.Personalizer.Models;

namespace PartnerUp.Recommendations.API.Clients;

public interface IPersonalizerRecommendationsClient
{
    Task<RankResponse> RankAsync(RankRequest rankRequest);

    Task RewardAsync(string eventId, double score);
}
