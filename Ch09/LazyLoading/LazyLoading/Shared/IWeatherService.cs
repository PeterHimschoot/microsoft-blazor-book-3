namespace LazyLoading.Shared
{
  public interface IWeatherService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecasts();
  }
}
