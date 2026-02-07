using PartnerUp.Recommendations.API.Models;

namespace PartnerUp.Recommendations.API.Services;

public interface IRecommendationsService
{
    Task<RecommendationViewModel> GetAsync(Guid teamId, string token);

    Task RankAsync(string eventId, int score);
}
