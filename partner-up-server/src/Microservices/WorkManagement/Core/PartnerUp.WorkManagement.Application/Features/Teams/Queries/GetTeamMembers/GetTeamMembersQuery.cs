using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQuery : IRequest<IEnumerable<UserResponse>>
{
    public Guid TeamId { get; set; } = default!;
}
