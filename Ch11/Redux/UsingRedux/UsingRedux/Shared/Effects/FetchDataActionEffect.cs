using Fluxor;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UsingRedux.Shared.Actions;

namespace UsingRedux.Shared.Effects
{
  public class FetchDataActionEffect : Effect<FetchDataAction>
  {
    private readonly HttpClient httpClient;

    public FetchDataActionEffect(HttpClient http)
      => this.httpClient = http;

    public override async Task HandleAsync(FetchDataAction action, IDispatcher dispatcher)
    {
      WeatherForecast[]? forecasts = await this.httpClient.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
      dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
  }
}
