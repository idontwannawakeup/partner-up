using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetTeamById;

public class GetTeamByIdQuery : IRequest<TeamResponse>
{
    public Guid Id { get; set; }
}
