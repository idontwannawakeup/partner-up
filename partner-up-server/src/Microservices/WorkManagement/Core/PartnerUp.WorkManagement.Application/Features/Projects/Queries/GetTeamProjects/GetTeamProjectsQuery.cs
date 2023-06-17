using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetTeamProjects;

public class GetTeamProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid TeamId { get; set; }
}
