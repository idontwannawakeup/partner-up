using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Parameters;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Domain.Parameters;

public class TeamsParameters : QueryStringParameters, IFilterParameters<Team>
{
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Specialization { get; set; }
}
