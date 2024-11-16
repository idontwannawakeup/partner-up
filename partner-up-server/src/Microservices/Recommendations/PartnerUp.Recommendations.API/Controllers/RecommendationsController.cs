using Microsoft.AspNetCore.Mvc;

namespace PartnerUp.Recommendations.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationsController : ControllerBase
{
    [HttpGet("{teamId:Guid}")]
    public async Task<IActionResult> Get(Guid teamId)
    {
        return Ok("Recommendations");
    }
}

public class TeamContext
{
    [NonSerialized]
    public Guid Id;
    public string Specialization { get; set; } = default!;
    public string About { get; set; } = default!;
    public List<UserProfile> Members { get; set; }
}

public class UserProfile
{
    [NonSerialized]
    public Guid Id;
    public string Profession { get; set; } = default!;
    public string Specialization { get; set; } = default!;
}
