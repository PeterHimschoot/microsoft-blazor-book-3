using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Blazor.Weather.Shared
{
  public static class Policies
  {
    public const string RoleAndCountry = "RoleAndCountry";

    public static AuthorizationPolicy RoleAndCountryPolicy()
        => new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("country", "BE")
        .Build();
  }
}