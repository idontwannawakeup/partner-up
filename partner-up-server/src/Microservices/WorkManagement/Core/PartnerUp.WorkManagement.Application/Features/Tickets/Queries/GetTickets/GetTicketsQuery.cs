using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Features.Tickets.Queries.GetTickets;

public class GetTicketsQuery : IRequest<PagedList<TicketResponse>>
{
    public TicketsParameters Parameters { get; set; } = default!;
}
