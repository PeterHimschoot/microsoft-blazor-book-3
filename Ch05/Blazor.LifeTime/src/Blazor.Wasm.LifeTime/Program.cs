using Blazor.LifeTime.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blazor.Wasm.LifeTime
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient
      {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
      });

      builder.Services.AddSingleton<SingletonService>();
      builder.Services.AddTransient<TransientService>();
      builder.Services.AddScoped<ScopedService>();

      await builder.Build().RunAsync();
    }
  }
}
