using LazyLoading.Library.Services;
using LazyLoading.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LazyLoading.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddScoped<IWeatherServiceFactory, WeatherServiceFactory>();

      builder.Services.AddScoped<LazyAssemblyLoader>();
      await builder.Build().RunAsync();
    }
  }
}
