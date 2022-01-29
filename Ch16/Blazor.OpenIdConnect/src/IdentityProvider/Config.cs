using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider
{
  public class Config
  {
    public static List<TestUser> GetUsers()
    => new List<TestUser>
    {
      new TestUser
      {
        SubjectId = "{223C9865-03BE-4951-8911-740A438FCF9D}",
        Username = "peter@u2u.be",
        Password = "u2u-secret",
        Claims = new List<Claim>
        {
          new Claim("given_name", "Peter"),
          new Claim(JwtClaimTypes.Name, "Peter Himschoot"),
          new Claim("family_name", "Himschoot"),
          new Claim("address", "Melle"),
          new Claim("role", "admin"),
        }
      },
      new TestUser
      {
        SubjectId = "{34119795-78A6-44C2-B128-30BFBC29139D}",
        Username = "student@u2u.be",
        Password = "u2u-secret",
        Claims = new List<Claim>
        {
          new Claim("given_name", "Student"),
          new Claim(JwtClaimTypes.Name, "Student Blazor"),
          new Claim("family_name", "Blazor"),
          new Claim("address", "Zellik"),
          new Claim("role", "tester"),
        }
      }
    };

    public static IEnumerable<IdentityResource> GetIdentityResources()
    => new List<IdentityResource>
    {
      new IdentityResources.OpenId(),
      new IdentityResources.Profile(),
      new IdentityResources.Address(),
      new IdentityResource(name: "roles",
        displayName: "User role(s)",
        userClaims: new List<string> { "role" }),
    };

    public static IEnumerable<Client> GetClients()
    => new List<Client>
    {
      new Client
      {
        ClientName = "Blazor Server",
        ClientId = "BlazorServer",
        AllowedGrantTypes = GrantTypes.Hybrid,
        RedirectUris = new List<string>{
          // The port number should correspond to the Blazor.Server.OpenIdConnect project
          // which you can find in launchSettings.json
          "https://localhost:5001/signin-oidc"
        },
        RequirePkce = false,
        AllowedScopes = {
          IdentityServerConstants.StandardScopes.OpenId,
          IdentityServerConstants.StandardScopes.Profile,
          IdentityServerConstants.StandardScopes.Address,
          "roles"
        },
        ClientSecrets = { new Secret("u2u-secret".Sha512()) },
        RequireConsent = true,
        PostLogoutRedirectUris = new List<string>
        {
          "https://localhost:5001/signout-callback-oidc"
        }
      }
    };
  }
}