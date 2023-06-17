using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetTeams;

public class GetTeamsQuery : IRequest<PagedList<TeamResponse>>
{
    public TeamsParameters Parameters { get; set; } = default!;
}
