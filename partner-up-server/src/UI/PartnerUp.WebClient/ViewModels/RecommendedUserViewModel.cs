namespace PartnerUp.WebClient.ViewModels;

public class RecommendedUserViewModel
{
    public Guid RecommendationId { get; set; }
    
    public string Profession { get; set; }
    
    public IEnumerable<string> Skills { get; set; }
}
