using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;

namespace PartnerUp.Content.Application.Features.Recent.Queries.GetRecentProjects;

public class GetRecentProjectsQuery : IRequest<IEnumerable<ProjectResponse>>
{
    public Guid UserId { get; set; }
}
