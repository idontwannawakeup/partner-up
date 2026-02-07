using PartnerUp.Recommendations.API.Controllers;

namespace PartnerUp.Recommendations.API.Models.Contexts;

public class TeamContext
{
    public string Name { get; set; } = default!;
    
    public string? Specialization { get; set; }
    
    public string? About { get; set; }
}
