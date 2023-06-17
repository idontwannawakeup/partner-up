using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;

namespace PartnerUp.Content.Application.Features.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQuery : IRequest<IEnumerable<TicketResponse>>
{
    public Guid UserId { get; set; }
}
