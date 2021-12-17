using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using static Blazor.Wasm.OpenIdConnect.Pages.FetchData;

namespace Blazor.Wasm.OpenIdConnect.Services
{
  public class WeatherForecastService
  {
    private readonly IHttpClientFactory httpClientFactory;

    public WeatherForecastService(IHttpClientFactory httpClientFactory)
      => this.httpClientFactory = httpClientFactory;

    public async ValueTask<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      HttpClient httpClient =
        this.httpClientFactory.CreateClient(nameof(WeatherForecastService));
      WeatherForecast[] result =
        await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
      return result;
    }
  }
}
