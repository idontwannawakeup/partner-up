using MediatR;

namespace PartnerUp.WorkManagement.Application.Features.Tickets.Commands.ExtendDeadline;

public class ExtendDeadlineCommand : IRequest
{
    public Guid Id { get; set; }
    public DateTime Deadline { get; set; }
}
