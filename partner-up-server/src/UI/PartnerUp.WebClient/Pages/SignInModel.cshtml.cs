using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PartnerUp.WebClient.Pages;

public class SignInModel : PageModel
{
    public Task<IActionResult> OnGetAsync(string redirectUri)
    {
        if (string.IsNullOrWhiteSpace(redirectUri))
        {
            redirectUri = Url.Content("~/");
        }

        if (HttpContext.User.Identity!.IsAuthenticated)
        {
            Response.Redirect(redirectUri);
        }

        return Task.FromResult<IActionResult>(Challenge(
            new AuthenticationProperties { RedirectUri = redirectUri },
            OpenIdConnectDefaults.AuthenticationScheme));
    }
}
