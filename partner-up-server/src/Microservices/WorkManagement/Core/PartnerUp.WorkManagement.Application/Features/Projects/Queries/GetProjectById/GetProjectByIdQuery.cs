using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public class GetProjectByIdQuery : IRequest<ProjectResponse>
{
    public Guid Id { get; set; }
}
