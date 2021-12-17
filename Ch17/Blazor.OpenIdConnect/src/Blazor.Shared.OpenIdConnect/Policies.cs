using Microsoft.AspNetCore.Authorization;

namespace Blazor.Shared.OpenIdConnect
{
  public static class Policies
  {
    public const string FromBelgium = "FromBelgium";

    public static AuthorizationPolicy FromBelgiumPolicy()
        => new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("country", "Belgium")
        .Build();
  }
}
