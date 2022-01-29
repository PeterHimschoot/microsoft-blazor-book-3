namespace Blazor.Server.OpenIdConnect.Data
{
  public class WeatherForecastService
  {
    private readonly IHttpClientFactory httpClientFactory;
    public WeatherForecastService(IHttpClientFactory httpClientFactory)
    => this.httpClientFactory = httpClientFactory;

    public async ValueTask<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
      HttpClient httpClient = this.httpClientFactory.CreateClient(nameof(WeatherForecastService));
      WeatherForecast[]? result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("weatherforecast");
      // Return empty array instead of null
      return result ?? Array.Empty<WeatherForecast>();
    }
  }
}