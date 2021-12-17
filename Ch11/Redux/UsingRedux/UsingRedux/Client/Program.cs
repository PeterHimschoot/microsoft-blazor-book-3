using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using UsingRedux.Shared.Stores;

namespace UsingRedux.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient
      {
        BaseAddress =
          new Uri(builder.HostEnvironment.BaseAddress)
      });

      Assembly storeAssembly
        = typeof(AppStore).Assembly;
      builder.Services
        .AddFluxor(options => options.ScanAssemblies(storeAssembly)
        .UseReduxDevTools());

      await builder.Build().RunAsync();
    }
  }
}
