using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;

namespace PartnerUp.WorkManagement.Application.Features.Tickets.Queries.GetTicketById;

public class GetTicketByIdQuery : IRequest<TicketResponse>
{
    public Guid Id { get; set; }
}
