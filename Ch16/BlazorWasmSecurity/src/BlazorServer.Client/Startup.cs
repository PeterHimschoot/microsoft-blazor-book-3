using Blazor.Weather.Shared;
using BlazorServer.Client.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;

namespace BlazorServer.Client
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddServerSideBlazor();

      services.AddAuthentication(options =>
      {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
      })
      .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
          options =>
          {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.Authority = "https://localhost:5021";
            options.ClientId = "BlazorServer";
            options.ClientSecret = "u2u-secret";

            // When set to code, the middleware will use PKCE protection
            options.ResponseType = "code id_token";

            // Save the tokens we receive from the IDP
            options.SaveTokens = true;

            // It's recommended to always get claims from the 
            // UserInfoEndpoint during the flow. 
            options.GetClaimsFromUserInfoEndpoint = true;

            // You can have certain claims removed from the token
            options.ClaimActions.DeleteClaims(new string[] { "sid", "idp" });

            // Or use the UserInfo endpoint

            // The "openid" and "profile" scopes are added automatically,
            // so we don't need to add them for this test 
            //options.Scope.Add("openid");
            //options.Scope.Add("profile");

            // We should add mappings for additional claims (not openid and profile)
            options.Scope.Add("address");
            options.ClaimActions.MapUniqueJsonKey("address", "address");

            options.Scope.Add("roles");
            options.ClaimActions.MapUniqueJsonKey("role", "role");
            options.TokenValidationParameters = new TokenValidationParameters
            {
              RoleClaimType = "role"
            };

            options.Scope.Add("u2uApi");


            //options.SignedOutCallbackPath = "/signout-callback-oidc";
          });

      // Add the IdentityModel.AspNetCore package for next

      services.AddAccessTokenManagement();
      services.AddUserAccessTokenHttpClient(
        nameof(WeatherForecastService), null, client =>
      {
        client.BaseAddress = new Uri("https://localhost:5011");
      });

      services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
    }
  }
}
