using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PizzaPlace.Client.Services;
using PizzaPlace.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaPlace.Client
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

      builder.Services.AddTransient<IMenuService, MenuService>();
      builder.Services.AddTransient<IOrderService, OrderService>();
      builder.Services.AddSingleton<State>();

      builder.Services.AddLocalization();

      WebAssemblyHost? host = builder.Build();
      await host.SetDefaultCulture();
      await host.RunAsync();
    }
  }
}
