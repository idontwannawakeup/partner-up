using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;

namespace PartnerUp.Content.Application.Features.Recent.Queries.GetRecentTeams;

public class GetRecentTeamsQuery : IRequest<IEnumerable<TeamResponse>>
{
    public Guid UserId { get; set; }
}
