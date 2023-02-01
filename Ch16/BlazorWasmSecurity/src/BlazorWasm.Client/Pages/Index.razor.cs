using Blazor.Weather.Shared;
using BlazorWasm.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Pages
{
  public partial class Index
  {
    [Inject]
    public AuthenticationStateProvider AuthenticationStateProvider { get; set; }

    [Inject]

    public IInfoService InfoService { get; set; }
    private IEnumerable<Claim> Claims { get; set; }

    private InfoMessage message;

    protected override async Task OnInitializedAsync()
    {
      AuthenticationState authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();

      if (authState is not null)
      {
        Claims = authState.User.Claims;

        // bool isAdmin = authState.User.FindAll("role").Any(cl => cl.Value == "admin");
      }

      message = await InfoService.GetInfo();
    }
  }
}
