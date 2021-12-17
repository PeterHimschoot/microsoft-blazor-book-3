using Dependency.Inversion.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Dependency.Inversion.Client
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

      builder.Services
             .AddSingleton<IProductsService, ProductsService>();

      ProductsService productsService = new ProductsService();
      builder.Services
             .AddSingleton<IProductsService>(productsService);

      builder.Services
       .AddSingleton<ProductsService>();

      builder.Services
             .AddTransient<IProductsService, ProductsService>();

      builder.Services
             .AddScoped<IProductsService, ProductsService>();

      builder.Services
             .AddScoped<ProductsService>();

      await builder.Build().RunAsync();
    }
  }
}
