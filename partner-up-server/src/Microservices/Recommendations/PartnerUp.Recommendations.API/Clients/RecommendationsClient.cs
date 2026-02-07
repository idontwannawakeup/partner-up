using Microsoft.Azure.CognitiveServices.Personalizer.Models;

namespace PartnerUp.Recommendations.API.Clients;

public class RecommendationsClient : IPersonalizerRecommendationsClient
{
    public Task<RankResponse> RankAsync(RankRequest rankRequest)
    {
        var rankedActions = rankRequest.Actions
            .Select(a => new RankedAction(a.Id, EvaluateCandidate(a.Features)))
            .ToList();
        
        var rankResponse = new RankResponse(rankedActions, rankRequest.EventId);
        return Task.FromResult(rankResponse);
    }

    public Task RewardAsync(string eventId, double score)
    {
        return Task.CompletedTask;
    }

    private static double EvaluateCandidate(IList<object> features)
    {
        return features.ElementAtOrDefault(0) is "Software Engineer" or "Developer"
            ? RandomRanking(91, 100)
            : RandomRanking(1, 90);
    }

    private static double RandomRanking(int min, int max)
    {
        return Random.Shared.Next(min, max) / 100.0;
    }
}
