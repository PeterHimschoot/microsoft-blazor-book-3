using Blazor.Weather.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Services
{
  public class WeatherForecastService : IWeatherForecastService
  {
    public class WeatherForecastAuthorizationMessageHandler : AuthorizationMessageHandler
    {
      public WeatherForecastAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation)
        : base(provider, navigation) => ConfigureHandler(
          authorizedUrls: new[] { "https://localhost:5011" }, // address of API
          scopes: new[] { "u2uApi" }
        );
    }

    private readonly IHttpClientFactory httpClientFactory;

    public WeatherForecastService(IHttpClientFactory httpClientFactory)
      => this.httpClientFactory = httpClientFactory;

    public async ValueTask<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      HttpClient httpClient = this.httpClientFactory.CreateClient(nameof(WeatherForecastService));
      WeatherForecast[] result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
      return result;
    }
  }
}
