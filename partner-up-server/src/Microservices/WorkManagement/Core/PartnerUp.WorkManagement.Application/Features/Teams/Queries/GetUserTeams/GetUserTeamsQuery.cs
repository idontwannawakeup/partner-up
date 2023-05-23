using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetUserTeams;

public class GetUserTeamsQuery : IRequest<IEnumerable<TeamResponse>>
{
    public Guid UserId { get; set; }
}
