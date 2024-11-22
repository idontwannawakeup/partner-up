using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Interfaces;

public interface IRecommendationsService
{
    Task<IEnumerable<RecommendedUserViewModel>> RecommendCandidates(
        JobDescriptionViewModel jobDescription);
}
