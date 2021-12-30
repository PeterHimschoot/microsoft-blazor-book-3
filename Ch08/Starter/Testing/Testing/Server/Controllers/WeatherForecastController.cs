using Microsoft.AspNetCore.Mvc;
using Testing.Shared;

namespace Testing.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IWeatherService weatherService;

    public WeatherForecastController(IWeatherService weatherService) => this.weatherService = weatherService;

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>?> Get()
      => await this.weatherService.GetForecasts();
  }
}