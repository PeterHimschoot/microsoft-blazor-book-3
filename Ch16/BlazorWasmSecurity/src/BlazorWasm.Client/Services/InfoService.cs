using Blazor.Weather.Shared;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Services
{
  public class InfoService : IInfoService
  {
    private readonly IHttpClientFactory httpClientFactory;

    public InfoService(IHttpClientFactory httpClientFactory)
    {
      this.httpClientFactory = httpClientFactory;
    }

    public async ValueTask<InfoMessage> GetInfo()
    {
      HttpClient httpClient = httpClientFactory.CreateClient(nameof(InfoService));
      return await httpClient.GetFromJsonAsync<InfoMessage>("info");
    }
  }
}
