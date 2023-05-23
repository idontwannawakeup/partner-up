using PartnerUp.Shared.Parameters;

namespace PartnerUp.Social.DataAccess.Common.Parameters;

public class FriendsParameters : QueryStringParameters
{
    public string? LastName { get; set; }
}
