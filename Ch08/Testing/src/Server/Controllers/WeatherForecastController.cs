using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Shared;

namespace Testing.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IWeatherService weatherService;

    public WeatherForecastController(IWeatherService weatherService)
    {
      this.weatherService = weatherService;
    }

    [HttpGet]
    public ValueTask<IEnumerable<WeatherForecast>> Get()
      => weatherService.GetForecasts();
  }
}
