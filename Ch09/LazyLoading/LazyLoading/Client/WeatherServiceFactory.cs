using LazyLoading.Client.Services;
using LazyLoading.Shared;

namespace LazyLoading.Client
{
  public class WeatherServiceFactory : IWeatherServiceFactory
  {
    private readonly HttpClient httpClient;

    public WeatherServiceFactory(HttpClient httpClient) 
      => this.httpClient = httpClient;

    public IWeatherService Create() 
      => new WeatherService(this.httpClient);
  }
}
