using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Testing.Shared
{
  public class WeatherService : IWeatherService
  {
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild",
      "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
     };

    private readonly ILogger<WeatherService> logger;

    public WeatherService(ILogger<WeatherService> logger)
    {
      this.logger = logger;
    }

    public ValueTask<IEnumerable<WeatherForecast>> GetForecasts()
    {
      logger.LogInformation($"{nameof(GetForecasts)} called at {DateTime.UtcNow}");
      var rng = new Random();
      var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      });
      return new ValueTask<IEnumerable<WeatherForecast>>(forecasts);
    }
  }
}
