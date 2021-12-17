using LazyLoading.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyLoading.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IWeatherService weatherService;

    public WeatherForecastController(IWeatherService weatherService)
      => this.weatherService = weatherService;

    [HttpGet("/forecasts")]
    public async Task<IEnumerable<WeatherForecast>> Get()
      => await weatherService.GetForecasts();
  }
}
