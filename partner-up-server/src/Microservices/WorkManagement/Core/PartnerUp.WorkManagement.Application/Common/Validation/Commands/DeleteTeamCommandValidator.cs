using FluentValidation;
using PartnerUp.WorkManagement.Application.Features.Teams.Commands.DeleteTeam;

namespace PartnerUp.WorkManagement.Application.Common.Validation.Commands;

public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
{
    public DeleteTeamCommandValidator()
    {
        RuleFor(team => team.Id)
            .NotEmpty()
            .WithMessage(team => $"{nameof(team.Id)} can't be empty.");
    }
}
