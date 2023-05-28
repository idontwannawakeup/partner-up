using PartnerUp.WebClient.Authentication;
using PartnerUp.WebClient.Extensions;
using PartnerUp.WebClient.Interfaces;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Services;

public class IdentityService : IIdentityService
{
    private readonly ApiHttpClient _httpClient;
    private readonly ApiAuthenticationStateProvider _stateProvider;

    public async Task<JwtViewModel> SignInAsync(UserSignInViewModel viewModel) =>
        await ExecuteRequestAsync("signIn", viewModel);

    public async Task<JwtViewModel> SignUpAsync(UserSignUpViewModel viewModel) =>
        await ExecuteRequestAsync("signUp", viewModel);

    private async Task<JwtViewModel> ExecuteRequestAsync<T>(string requestUri, T model)
    {
        var jwtModel = await _httpClient.PostWithoutAuthorizationAsync<T, JwtViewModel>(
            requestUri,
            model);

        await _stateProvider.MarkUserAsAuthenticatedAsync(jwtModel.Token);
        return jwtModel;
    }

    public IdentityService(HttpClient httpClient,
        ApiAuthenticationStateProvider stateProvider)
    {
        _httpClient = new ApiHttpClientBuilder(httpClient).AddAuthorization(stateProvider)
                                                          .Build();

        _stateProvider = stateProvider;
    }
}
