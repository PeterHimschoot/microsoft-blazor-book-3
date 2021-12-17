using Blazor.Shared.OpenIdConnect;
using Blazor.Wasm.OpenIdConnect.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Wasm.OpenIdConnect
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp
      => new HttpClient
      {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
      });

      builder.Services
        .AddHttpClient<WeatherForecastService>(
          client
          => client.BaseAddress = new Uri("https://localhost:5005")
        )
        .AddHttpMessageHandler(handlerConfig =>
        {
          AuthorizationMessageHandler handler =
          handlerConfig.GetService<AuthorizationMessageHandler>()
          .ConfigureHandler(
              authorizedUrls: new[] { "https://localhost:5005" }, // address of API
              scopes: new[] { "u2uApi" }
           );
          return handler;
        });

      builder.Services.AddSingleton<WeatherForecastService>();

      builder.Services.AddOidcAuthentication(options
      =>
      {
        // Configure your authentication provider options here.
        // For more information, see https://aka.ms/blazor-standalone-auth
        builder.Configuration.Bind("oidc", options.ProviderOptions);

        // We need to explain which claim contains the roles of the user
        options.UserOptions.RoleClaim = "role";
      });

      builder.Services.AddAuthorizationCore(options =>
      {
        options.AddPolicy(Policies.FromBelgium, Policies.FromBelgiumPolicy());
      });

      await builder.Build().RunAsync();
    }
  }
}
