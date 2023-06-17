using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQuery : IRequest<PagedList<ProjectResponse>>
{
    public ProjectsParameters Parameters { get; set; } = default!;
}
