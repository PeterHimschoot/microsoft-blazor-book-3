using LazyLoading.Shared;
using Microsoft.AspNetCore.Mvc;

namespace LazyLoading.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService) 
      => this._weatherService = weatherService;

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
      => await this._weatherService.GetForecasts();
  }
}