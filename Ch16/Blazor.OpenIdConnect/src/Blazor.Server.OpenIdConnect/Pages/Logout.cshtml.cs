using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Blazor.Server.OpenIdConnect.Pages
{
  public class LogoutModel : PageModel
  {
    public async Task<IActionResult> OnGetAsync()
    {
      // just to remove compiler warning
      await Task.CompletedTask;
      return SignOut(OpenIdConnectDefaults.AuthenticationScheme,
                     CookieAuthenticationDefaults.AuthenticationScheme);
    }
  }
}
