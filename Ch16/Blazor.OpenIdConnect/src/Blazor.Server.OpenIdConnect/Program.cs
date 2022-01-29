using Blazor.Server.OpenIdConnect.Data;
using Blazor.Shared.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddAuthentication(options =>
{
  options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
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

  // We should add mappings for additional claims
  // (not openid and profile)
  options.Scope.Add("address");
  options.ClaimActions.MapUniqueJsonKey("address", "address");
  options.ClaimActions.DeleteClaims("sid", "s_hash");

  options.Scope.Add("roles");
  options.ClaimActions.MapUniqueJsonKey("role", "role");
  options.TokenValidationParameters = new TokenValidationParameters
  {
    RoleClaimType = "role"
  };

  options.Scope.Add("u2uApi");

  options.Scope.Add("country");
  options.ClaimActions.MapUniqueJsonKey("country", "country");
});

// Handling the access token
builder.Services.AddAccessTokenManagement();
builder.Services.AddUserAccessTokenHttpClient(nameof(WeatherForecastService), null, 
  client =>
  {
    client.BaseAddress = new Uri("https://localhost:5005");
  });

// Policies
builder.Services.AddAuthorization(options =>
{
  // Using the shared policy from project Blazor.Shared.OpenIdConnect
  options.AddPolicy(Policies.FromBelgium, Policies.FromBelgiumPolicy());
  //options.AddPolicy("FromBelgium", policyBuilder =>
  //{
  //  policyBuilder.RequireAuthenticatedUser();
  //  policyBuilder.RequireClaim("country", "Belgium");
  //});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
