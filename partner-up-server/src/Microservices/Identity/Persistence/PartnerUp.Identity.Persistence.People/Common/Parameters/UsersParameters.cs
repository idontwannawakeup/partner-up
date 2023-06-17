using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Parameters;

namespace PartnerUp.Identity.Persistence.People.Common.Parameters;

public class UsersParameters : QueryStringParameters, IFilterParameters<User>
{
    // TODO: think about what to do with TeamId, current solution - get members with teams controller
    // public Guid? TeamId { get; set; }
    public string? LastName { get; set; }
}
