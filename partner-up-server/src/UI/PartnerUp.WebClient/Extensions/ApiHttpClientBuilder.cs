using PartnerUp.WebClient.Authentication;

namespace PartnerUp.WebClient.Extensions;

public class ApiHttpClientBuilder
{
    private readonly HttpClient _httpClient;

    private ApiAuthenticationStateProvider _stateProvider;

    public ApiHttpClientBuilder AddAuthorization(ApiAuthenticationStateProvider stateProvider)
    {
        _stateProvider = stateProvider;
        return this;
    }

    public ApiHttpClient Build() => new(_httpClient, _stateProvider!);

    public ApiHttpClientBuilder(HttpClient httpClient) => _httpClient = httpClient;
}
