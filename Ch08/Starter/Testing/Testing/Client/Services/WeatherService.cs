using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Testing.Shared;

namespace Testing.Client.Services
{
  public class WeatherService : IWeatherService
  {
    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }

    public async ValueTask<IEnumerable<WeatherForecast>?> GetForecasts()
      => await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast");
  }
}
