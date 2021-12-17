using BlazorWithgRPC.Client.Services;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWithgRPC.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      builder.Services.AddScoped<ForecastService>();

      builder.Services.AddScoped<ForecastGrpcService>();

      builder.Services
        .AddScoped(services =>
        {
          IConfiguration config =
            services.GetRequiredService<IConfiguration>();
          string backEndUrl = config["gRPC:weatherServices"];
          var httpHandler =
            new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
          return GrpcChannel.ForAddress(backEndUrl,
            new GrpcChannelOptions { HttpHandler = httpHandler });
        });

      await builder.Build().RunAsync();
    }
  }
}
