using BlazorWithgRPC.Shared.Protos;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithgRPC.Server.Services
{
  public class WeatherForecastProtoService
    : protoWeatherForecasts.protoWeatherForecastsBase
  {
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly ImageService imageService;

    public WeatherForecastProtoService(ImageService imageService) => this.imageService = imageService;

    public override Task<getForecastsResponse> getForecasts(getForecastsRequest request, ServerCallContext context)
    {
      System.Collections.Generic.IEnumerable<weatherForecast>? forecasts = Enumerable.Range(1, 5)
      .Select(index => new weatherForecast
      {
        Date = Timestamp.FromDateTime(DateTime.UtcNow.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)],
        Image = ByteString.CopyFrom(this.imageService.RandomImage())
      });

      var response = new getForecastsResponse();
      response.Forecasts.AddRange(forecasts);

      return Task.FromResult(response);
    }
  }
}
