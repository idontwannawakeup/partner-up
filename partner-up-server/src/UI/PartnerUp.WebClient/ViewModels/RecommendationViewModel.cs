namespace PartnerUp.WebClient.ViewModels;

public class RecommendationViewModel
{
    
    public string EventId { get; set; }
    
    public IEnumerable<UserViewModel> Candidates { get; set; }
}
