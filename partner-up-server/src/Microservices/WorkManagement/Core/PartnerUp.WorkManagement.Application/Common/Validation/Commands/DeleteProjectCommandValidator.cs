using FluentValidation;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

namespace PartnerUp.WorkManagement.Application.Common.Validation.Commands;

public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
{
    public DeleteProjectCommandValidator()
    {
        RuleFor(project => project.Id)
            .NotEmpty()
            .WithMessage(project => $"{nameof(project.Id)} can't be empty.");
    }
}
