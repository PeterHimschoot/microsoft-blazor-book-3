using LazyLoading.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LazyLoading.Library.Services
{
  public class WeatherService : IWeatherService
  {
    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }

    public async ValueTask<IEnumerable<WeatherForecast>> GetForecasts()
    {
      return await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("forecasts");
    }
  }
}
