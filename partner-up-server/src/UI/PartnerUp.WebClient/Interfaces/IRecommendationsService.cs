using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Interfaces;

public interface IRecommendationsService
{
    Task<RecommendationViewModel> RecommendAsync(Guid teamId);
    
    Task RankAsync(Guid eventId, int score);
}
