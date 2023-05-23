using PartnerUp.Social.DataAccess.Data.Entities;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Parameters;

namespace PartnerUp.Social.DataAccess.Common.Parameters;

public class RatingsParameters : QueryStringParameters, IFilterParameters<Rating>
{
    public Guid? RatedUserId { get; set; }
}
