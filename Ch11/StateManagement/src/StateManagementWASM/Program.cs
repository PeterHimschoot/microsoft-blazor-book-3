using JSInterop.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StateManagementWASM.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StateManagementWASM
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder =
        WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services
        .AddScoped(
        sp
        => new HttpClient
        {
          BaseAddress = new Uri("https://localhost:5011/state")
        });

      builder.Services
        .AddSingleton<ILocalStorage, LocalStorageWithModule>();

      builder.Services
        .AddScoped<StateService<int>>();

      await builder.Build().RunAsync();
    }
  }
}
