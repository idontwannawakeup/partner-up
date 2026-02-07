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
        return Task.FromResult<AuthenticationState>(default);
    }

    public Task MarkUserAsAuthenticatedAsync(string encryptedToken)
    {
        return Task.CompletedTask;
    }

    public Task MarkUserAsLoggedOutAsync()
    {
        return Task.CompletedTask;
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
