using LazyLoading.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoading.Client.Services
{
  public class WeatherService : IWeatherService
  {
    private readonly HttpClient httpClient;

    public WeatherService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }

    public async ValueTask<IEnumerable<WeatherForecast>> GetForecasts()
      => await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
  }
}
