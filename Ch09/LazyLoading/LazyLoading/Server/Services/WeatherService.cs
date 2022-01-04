using LazyLoading.Shared;

namespace LazyLoading.Server.Services
{
  public class WeatherService : IWeatherService
  {

    private static readonly string[] Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public ValueTask<IEnumerable<WeatherForecast>> GetForecasts() => ValueTask.FromResult(
        Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
          Date = DateTime.Now.AddDays(index),
          TemperatureC = Random.Shared.Next(-20, 55),
          Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
      );
  }
}
