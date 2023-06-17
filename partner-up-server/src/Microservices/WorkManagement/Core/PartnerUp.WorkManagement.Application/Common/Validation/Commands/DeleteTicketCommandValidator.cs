using FluentValidation;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.DeleteTicket;

namespace PartnerUp.WorkManagement.Application.Common.Validation.Commands;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(ticket => ticket.Id)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Id)} can't be empty.");
    }
}
