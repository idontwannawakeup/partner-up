namespace PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;

public class JwtResponse
{
    public string Token { get; set; } = default!;
    public Guid UserId { get; set; }
}
