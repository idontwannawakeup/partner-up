using System.Net.Http.Headers;
using Microsoft.Azure.CognitiveServices.Personalizer.Models;
using PartnerUp.Recommendations.API.Clients;
using PartnerUp.Recommendations.API.Common;
using PartnerUp.Recommendations.API.Models;
using PartnerUp.Recommendations.API.Models.Contexts;

namespace PartnerUp.Recommendations.API.Services;

public class PersonalizerRecommendationsService : IRecommendationsService
{
    private readonly ApiHttpClient _peopleClient;
    private readonly ApiHttpClient _workManagementClient;
    private readonly IPersonalizerRecommendationsClient _personalizerClient;
    
    public PersonalizerRecommendationsService(
        IdentityPeopleHttpClient peopleClient,
        WorkManagementHttpClient workManagementClient,
        IPersonalizerRecommendationsClient personalizerClient)
    {
        _personalizerClient = personalizerClient;
        _workManagementClient = new ApiHttpClient(workManagementClient.Client);
        _peopleClient = new ApiHttpClient(peopleClient.Client);
    }
    
    public async Task<RecommendationViewModel> GetAsync(Guid teamId, string token)
    {
        _peopleClient.Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(token);
        _workManagementClient.Client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(token);
        
        var candidates = await _peopleClient.GetAsync<List<UserViewModel>>("api/Users");
        var team = await _workManagementClient.GetAsync<TeamViewModel>($"api/Teams/{teamId}");
        
        var actions = MapActions(candidates);
        var context = MapContextFeatures(team);

        var eventId = Guid.NewGuid().ToString("B");
        var rankRequest = new RankRequest(actions, context, eventId: eventId);
        var response = await _personalizerClient.RankAsync(rankRequest);

        const double tolerance = 0.9;
        var recommendedCandidateIds = response.Ranking
            .Where(r => r.Probability > tolerance)
            .OrderByDescending(r => r.Probability)
            .Select(r => r.Id);

        var recommendedCandidates = candidates.Where(
            c => recommendedCandidateIds.Any(id => id == c.Id.ToString("B")));
        
        return new RecommendationViewModel
        {
            EventId = response.EventId,
            Candidates =  recommendedCandidates,
        };
    }

    public async Task RankAsync(string eventId, int score)
    {
        await _personalizerClient.RewardAsync(eventId, score);
    }

    private static List<RankableAction> MapActions(List<UserViewModel> candidates)
    {
        return candidates
            .Select(c => new RankableAction(
                c.Id.ToString("B"), 
                new List<object> { c.Profession, c.Specialization }))
            .ToList();
    }

    private static List<object> MapContextFeatures(TeamViewModel team)
    {
        return new List<object>
        {
            new Dictionary<string, object>
            {
                {
                    "team",
                    new TeamContext
                    {
                        Name = team.Name,
                        About = team.About,
                        Specialization = team.Specialization
                    }
                },
            }
        };
    }
}
