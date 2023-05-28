using FluentValidation;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Validation;

public class FriendsViewModelValidator : AbstractValidator<FriendsViewModel>
{
    public FriendsViewModelValidator()
    {
        RuleFor(request => request.FirstId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.FirstId)} can't be empty.");

        RuleFor(request => request.SecondId)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.SecondId)} can't be empty.");

        RuleFor(request => request.Second)
            .NotEmpty()
            .WithMessage(request => $"{nameof(request.Second)} can't be empty.");
    }
}
