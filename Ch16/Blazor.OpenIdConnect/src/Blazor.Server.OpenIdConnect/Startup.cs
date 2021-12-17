using Blazor.Server.OpenIdConnect.Data;
using Blazor.Shared.OpenIdConnect;
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

namespace Blazor.Server.OpenIdConnect
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
      services.AddSingleton<WeatherForecastService>();

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
        options.Authority = "https://localhost:5011";
        options.ClientId = "BlazorServer";
        options.ClientSecret = "u2u-secret";

        // When set to code, the middleware will use PKCE protection
        options.ResponseType = "code id_token";

        // Save the tokens we receive from the IDP
        options.SaveTokens = true;

        // It's recommended to always get claims from the 
        // UserInfoEndpoint during the flow. 
        options.GetClaimsFromUserInfoEndpoint = true;

        // We should add mappings for additional claims (not openid and profile)
        options.Scope.Add("address");
        options.ClaimActions
               .MapUniqueJsonKey("address", "address");
        options.ClaimActions
               .DeleteClaims("sid", "s_hash");

        options.Scope.Add("roles");
        options.ClaimActions.MapUniqueJsonKey("role", "role");
        options.TokenValidationParameters = new TokenValidationParameters
        {
          RoleClaimType = "role"
        };

        // Save the tokens we receive from the IDP
        options.SaveTokens = true;

        options.Scope.Add("u2uApi");

        options.Scope.Add("country");
        options.ClaimActions.MapUniqueJsonKey("country", "country");

      });

      services.AddAccessTokenManagement();
      //configure =>
      //{
      //  configure.Client.DefaultClient.Scope = "u2uApi country";
      //});
      services.AddUserAccessTokenHttpClient(
        nameof(WeatherForecastService), null, client =>
        {
          client.BaseAddress = new Uri("https://localhost:5005");
        });

      services.AddAuthorization(options =>
      {
        options.AddPolicy(Policies.FromBelgium,
          Policies.FromBelgiumPolicy());
      });
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
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
