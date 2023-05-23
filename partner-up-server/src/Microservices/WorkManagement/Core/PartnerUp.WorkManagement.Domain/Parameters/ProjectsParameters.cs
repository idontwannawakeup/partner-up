using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Parameters;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Domain.Parameters;

public class ProjectsParameters : QueryStringParameters, IFilterParameters<Project>
{
    public Guid? TeamId { get; set; }
    public Guid? TeamMemberId { get; set; }
    public string? Title { get; set; }
}
