using LazyLoading.Library.Services;
using LazyLoading.Shared;
using System.Net.Http;

namespace LazyLoading.Client
{
  public class WeatherServiceFactory : IWeatherServiceFactory
  {
    private readonly HttpClient httpClient;

    public WeatherServiceFactory(HttpClient httpClient)
    {
      this.httpClient = httpClient;
    }

    public IWeatherService Create() => new WeatherService(httpClient);
  }
}
