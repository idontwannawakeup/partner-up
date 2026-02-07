using Microsoft.AspNetCore.Mvc;
using PartnerUp.Recommendations.API.Services;

namespace PartnerUp.Recommendations.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationsService _recommendationsService;

    public RecommendationsController(IRecommendationsService recommendationsService)
    {
        _recommendationsService = recommendationsService;
    }

    [HttpGet("{teamId:Guid}")]
    public async Task<IActionResult> Get(Guid teamId)
    {
        var token = HttpContext.Request.Headers.Authorization;
        var recommendedUsers = await _recommendationsService.GetAsync(teamId, token);
        return Ok(recommendedUsers);
    }

    [HttpPost("{eventId:Guid}/{score:int}")]
    public async Task<IActionResult> RankAsync(Guid eventId, int score)
    {
        var token = HttpContext.Request.Headers.Authorization;
        await _recommendationsService.RankAsync(eventId.ToString("B"), score);
        return Ok();
    }
}
