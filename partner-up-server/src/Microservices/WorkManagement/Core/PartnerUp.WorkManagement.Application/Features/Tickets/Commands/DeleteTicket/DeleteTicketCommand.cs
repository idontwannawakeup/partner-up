using MediatR;

namespace PartnerUp.WorkManagement.Application.Features.Tickets.Commands.DeleteTicket;

public class DeleteTicketCommand : IRequest
{
    public Guid Id { get; set; }
}
