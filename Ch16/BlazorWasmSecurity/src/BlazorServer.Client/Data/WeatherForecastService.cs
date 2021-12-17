using Blazor.Weather.Shared;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorServer.Client.Data
{
  public class WeatherForecastService : IWeatherForecastService
  {
    private readonly IHttpClientFactory httpClientFactory;

    public WeatherForecastService(IHttpClientFactory httpClientFactory)
    {
      this.httpClientFactory = httpClientFactory;
    }

    public async ValueTask<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      HttpClient httpClient = httpClientFactory.CreateClient(nameof(WeatherForecastService));
      var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
      return result;
    }
  }
}
