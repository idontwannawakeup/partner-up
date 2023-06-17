using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PartnerUp.WebClient.Pages;

public class SignOutModel : PageModel
{
    private readonly IConfiguration _config;

    public SignOutModel(IConfiguration config)
    {
        this._config = config;
    }

    public Task<IActionResult> OnGetAsync()
    {
        return Task.FromResult<IActionResult>(SignOut(
            new AuthenticationProperties { RedirectUri = _config["ApplicationUrl"] },
            OpenIdConnectDefaults.AuthenticationScheme,
            CookieAuthenticationDefaults.AuthenticationScheme));
    }
}
