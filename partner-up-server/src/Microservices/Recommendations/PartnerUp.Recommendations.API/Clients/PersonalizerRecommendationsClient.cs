using Microsoft.Azure.CognitiveServices.Personalizer;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;

namespace PartnerUp.Recommendations.API.Clients;

public class PersonalizerRecommendationsClient : IPersonalizerRecommendationsClient
{
    private readonly IPersonalizerClient _personalizerClient;

    public PersonalizerRecommendationsClient(IPersonalizerClient personalizerClient)
    {
        _personalizerClient = personalizerClient;
    }

    public async Task<RankResponse> RankAsync(RankRequest rankRequest)
    {
        return await _personalizerClient.RankAsync(rankRequest);
    }

    public async Task RewardAsync(string eventId, double score)
    {
        await _personalizerClient.RewardAsync(eventId, score);
    }
}
