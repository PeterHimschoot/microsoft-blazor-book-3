using Blazor.Weather.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      this._logger = logger;
    }

    //[Authorize()]
    //[Authorize(Roles = "admin")]
    [Authorize(Policy = Policies.RoleAndCountry)]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      IEnumerable<System.Security.Claims.Claim> claims = User.Claims;

      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [AllowAnonymous]
    [HttpGet("/info")]
    public IActionResult Info()
    {
      return Ok(new InfoMessage("Anonymous"));
    }
  }
}
