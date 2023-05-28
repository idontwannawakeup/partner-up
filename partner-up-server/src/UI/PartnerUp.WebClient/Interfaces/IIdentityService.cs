using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Interfaces;

public interface IIdentityService
{
    Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel);

    Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel);
}
