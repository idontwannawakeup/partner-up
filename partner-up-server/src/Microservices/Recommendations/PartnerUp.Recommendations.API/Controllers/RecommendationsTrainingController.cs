using Microsoft.Azure.CognitiveServices.Personalizer;

namespace PartnerUp.Recommendations.API.Controllers;

public class RecommendationsTrainingController
{
    private readonly PersonalizerClient _personalizerClient;

    public RecommendationsTrainingController(PersonalizerClient personalizerClient)
    {
        _personalizerClient = personalizerClient;
    }
}
