using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorServer.Client.Pages
{
  [Authorize]
  public partial class Index
  {
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    private IEnumerable<Claim> Claims { get; set; }

    protected override async Task OnInitializedAsync()
    {
      AuthenticationState authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

      if (authState is not null)
      {
        Claims = authState.User.Claims;
      }
    }
  }
}
