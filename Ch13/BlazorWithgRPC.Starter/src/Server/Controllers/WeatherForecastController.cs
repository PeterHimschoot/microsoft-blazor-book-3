using BlazorWithgRPC.Server.Services;
using BlazorWithgRPC.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorWithgRPC.Server.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ImageService imageService;

    public WeatherForecastController(ImageService imageService) => this.imageService = imageService;

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
      => Enumerable.Range(1, 5)
      .Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
        Image = this.imageService.RandomImage()
      })
    .ToArray();
  }
}
