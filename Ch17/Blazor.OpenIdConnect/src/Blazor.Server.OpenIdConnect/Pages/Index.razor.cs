using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blazor.Server.OpenIdConnect.Pages
{
  public partial class Index
  {
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private IEnumerable<Claim> Claims { get; set; }

    public string UserName { get; set; } = "Unknown";

    protected override async Task OnInitializedAsync()
    {
      AuthenticationState authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

      if (authState is not null)
      {
        Claims = authState.User.Claims;

        Claim givenNameClaim =
          authState.User.FindFirst("given_name");
        if (givenNameClaim is not null)
        {
          UserName = givenNameClaim.Value;
        }
      }
    }
  }
}
