using FluentValidation;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Validation;

public class UserSignInViewModelValidator : AbstractValidator<UserSignInViewModel>
{
    public UserSignInViewModelValidator()
    {
        RuleFor(request => request.UserName)
            .NotEmpty()
            .WithMessage("UserName can't be empty.");

        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage("Password can't be empty.");
    }
}
