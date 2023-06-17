using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

namespace PartnerUp.WebClient.Authentication;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorage;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private static AuthenticationState AnonymousState =>
        new(new ClaimsPrincipal(new ClaimsIdentity()));

    public async Task<string> GetJwtTokenAsync()
    {
        return await _httpContextAccessor.HttpContext?.GetTokenAsync("access_token")!;
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // var encryptedToken = await _localStorage.GetItemAsync<string>("securityToken");
        // if (encryptedToken is null)
        // {
        //     return AnonymousState;
        // }
        //
        // var token = new JwtSecurityTokenHandler().ReadJwtToken(encryptedToken);
        // return GenerateStateFromToken(token);
        return Task.FromResult<AuthenticationState>(default);
    }

    public async Task MarkUserAsAuthenticatedAsync(string encryptedToken)
    {
        // await _localStorage.SetItemAsync("securityToken", encryptedToken);
        // var token = new JwtSecurityTokenHandler().ReadJwtToken(encryptedToken);
        // var state = GenerateStateFromToken(token);
        // NotifyAuthenticationStateChanged(Task.FromResult(state));
    }

    public async Task MarkUserAsLoggedOutAsync()
    {
        // await _localStorage.RemoveItemAsync("securityToken");
        // NotifyAuthenticationStateChanged(Task.FromResult(AnonymousState));
    }

    public static async Task<Guid> GetUserIdFromStateAsync(Task<AuthenticationState> state)
    {
        var awaitedState = await state;
        var claims = awaitedState.User.Claims;
        var id = claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
        return new Guid(id);
    }

    private static AuthenticationState GenerateStateFromToken(JwtSecurityToken token)
    {
        var identity = new ClaimsIdentity(token.Claims, "apiauth_type");
        var principal = new ClaimsPrincipal(identity);
        return new AuthenticationState(principal);
    }

    public ApiAuthenticationStateProvider(ILocalStorageService localStorage, IHttpContextAccessor httpContextAccessor)
    {
        _localStorage = localStorage;
        _httpContextAccessor = httpContextAccessor;
    }
}
