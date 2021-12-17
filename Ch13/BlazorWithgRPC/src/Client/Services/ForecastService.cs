using BlazorWithgRPC.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWithgRPC.Client.Services
{
  public class ForecastService
  {
    private readonly HttpClient httpClient;

    public ForecastService(HttpClient httpClient)
      => this.httpClient = httpClient;

    public async Task<IEnumerable<WeatherForecast>?> GetForecasts()
      => await this.httpClient
           .GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
  }
}
