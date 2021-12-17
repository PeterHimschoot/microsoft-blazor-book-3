using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BlazorServer.Client.Pages
{
  public class LogoutModel : PageModel
  {
    public async Task<IActionResult> OnGetAsync()
    {
      // just to remove compiler warning
      await Task.CompletedTask;
      return SignOut(
          new AuthenticationProperties
          {
            RedirectUri = "https://localhost:44388"
          },
          OpenIdConnectDefaults.AuthenticationScheme,
          CookieAuthenticationDefaults.AuthenticationScheme);
    }
  }
}
