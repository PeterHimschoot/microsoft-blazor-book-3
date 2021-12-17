using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

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
          //new Claim("role", "developer"),
          new Claim("country", "Belgium"),
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
          //new Claim("role", "user"),
          new Claim("role", "tester"),
          new Claim("country", "France"),
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
      new IdentityResource(name: "country",
        displayName: "User country",
        userClaims: new List<string> { "country" })
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
          "https://localhost:5001/signin-oidc"
        },
        RequirePkce = false,
        AllowedScopes = {
          IdentityServerConstants.StandardScopes.OpenId,
          IdentityServerConstants.StandardScopes.Profile,
          IdentityServerConstants.StandardScopes.Address,
          "roles",
          "u2uApi",
          "country"
        },
        ClientSecrets = { new Secret("u2u-secret".Sha512()) },
        RequireConsent = true,
        PostLogoutRedirectUris = new List<string>
        {
          "https://localhost:5001/signout-callback-oidc"
        }
      }
    };

    public static IEnumerable<ApiScope> GetApiScopes()
      => new List<ApiScope>
      {
        new ApiScope("u2uApi", "U2U API")
      };

    public static IEnumerable<ApiResource> GetApiResources()
      => new List<ApiResource>
      {
        new ApiResource("u2uApi", "U2U API")
        {
            // To use user's country claim we need to add it here
            Scopes = { "u2uApi" }, UserClaims = new [] { "country"}
        },
        //new ApiResource("country", "User country",
        //  new [] { "country"})
      };
  }
}
