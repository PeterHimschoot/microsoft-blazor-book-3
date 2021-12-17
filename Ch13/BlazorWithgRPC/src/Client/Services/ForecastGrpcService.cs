using BlazorWithgRPC.Shared;
using BlazorWithgRPC.Shared.Protos;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithgRPC.Client.Services
{
  public class ForecastGrpcService
  {
    private readonly GrpcChannel grpcChannel;

    public ForecastGrpcService(GrpcChannel grpcChannel)
      => this.grpcChannel = grpcChannel;

    public async Task<IEnumerable<WeatherForecast>?> GetForecasts()
    {
      var client =
        new protoWeatherForecasts.protoWeatherForecastsClient(this.grpcChannel);

      var request = new getForecastsRequest();

      getForecastsResponse? response = await client.getForecastsAsync(request);

      return response.Forecasts.Select(f =>
        new WeatherForecast
        {
          Date = f.Date.ToDateTime(),
          TemperatureC = f.TemperatureC,
          Summary = f.Summary,
          Image = f.Image.ToByteArray()
        });
    }
  }
}
