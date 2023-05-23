using FluentValidation;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.ExtendDeadline;

namespace PartnerUp.WorkManagement.Application.Common.Validation.Commands;

public class ExtendDeadlineCommandValidator : AbstractValidator<ExtendDeadlineCommand>
{
    public ExtendDeadlineCommandValidator()
    {
        RuleFor(ticket => ticket.Id)
            .NotEmpty()
            .WithMessage(ticket => $"{nameof(ticket.Id)} can't be empty.");

        RuleFor(ticket => ticket.Deadline)
            .GreaterThan(DateTime.Now)
            .WithMessage(ticket => $"{nameof(ticket.Deadline)} should be later than now.");
    }
}
