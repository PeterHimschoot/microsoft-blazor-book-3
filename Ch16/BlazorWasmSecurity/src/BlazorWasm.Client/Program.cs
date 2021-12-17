using Blazor.Weather.Shared;
using BlazorWasm.Client.ClaimsPrincipalFactory;
using BlazorWasm.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWasm.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      //builder.Services
      //  .AddHttpClient<WeatherForecastService>(
      //    client => client.BaseAddress = new Uri("https://localhost:5011")
      //  )
      //  .AddHttpMessageHandler(sp =>
      //  {
      //    var handler = sp.GetService<AuthorizationMessageHandler>()
      //    .ConfigureHandler(
      //        authorizedUrls: new[] { "https://localhost:5011" }, // address of API
      //        scopes: new[] { "u2uApi" }
      //     );
      //    return handler;
      //  });

      builder.Services
        .AddScoped<WeatherForecastService.WeatherForecastAuthorizationMessageHandler>();
      builder.Services
        .AddHttpClient(nameof(WeatherForecastService), client =>
        {
          client.BaseAddress = new Uri("https://localhost:5011");
        })
        .AddHttpMessageHandler<WeatherForecastService.WeatherForecastAuthorizationMessageHandler>();
      // builder.Services.AddScoped(
      //   sp => sp.GetService<IHttpClientFactory>().CreateClient(nameof(WeatherForecastService)));
      builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();

      builder.Services.AddHttpClient(nameof(InfoService), client =>
      {
        client.BaseAddress = new Uri("https://localhost:5011");
      });
      builder.Services.AddTransient<IInfoService, InfoService>();

      builder.Services.AddOidcAuthentication(options =>
      {
        options.ProviderOptions.Authority = "https://localhost:5021/";
        options.ProviderOptions.ClientId = "BlazorWasm";
        options.ProviderOptions.ResponseType = "code";

        options.ProviderOptions.DefaultScopes.Add("u2uApi");
        options.ProviderOptions.DefaultScopes.Add("country");

        options.ProviderOptions.PostLogoutRedirectUri = "authentication/logout-callback";
        options.ProviderOptions.RedirectUri = "authentication/login-callback";

        // We need to explain which claim contains the roles of the user
        options.UserOptions.RoleClaim = "role";
      })
      .AddAccountClaimsPrincipalFactory<RoleClaimsPrincipalFactory<RemoteUserAccount>>();

      builder.Services.AddAuthorizationCore(options =>
        {
          options.AddPolicy(Policies.RoleAndCountry, Policies.RoleAndCountryPolicy());
        });

      await builder.Build().RunAsync();
    }
  }
}
