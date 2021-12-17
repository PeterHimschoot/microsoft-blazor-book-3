using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorWasm.Client.AuthenticationStateProviders
{
  public class CustomAuthStateProvider : AuthenticationStateProvider
  {
    // Don't forget to register this as a Scoped instance in dependency injection
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      // Here you would fetch the claims for the user...
      var identity = new ClaimsIdentity(new[]
      {
        new Claim(ClaimTypes.Name, "Peter"),
      }, "Fake authentication type");

      var user = new ClaimsPrincipal(identity);
      return Task.FromResult(new AuthenticationState(user));
    }
  }
}
