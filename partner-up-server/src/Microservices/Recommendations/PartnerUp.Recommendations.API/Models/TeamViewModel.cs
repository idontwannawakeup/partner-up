namespace PartnerUp.Recommendations.API.Models;

public class TeamViewModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public string? Specialization { get; set; }
    
    public string? About { get; set; }
}
