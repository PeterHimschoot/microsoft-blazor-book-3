using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;
using System.Threading.Tasks;

namespace PizzaPlace.Client
{
  public static class WebAssemblyHostExtension
  {
    public static async Task SetDefaultCulture(this WebAssemblyHost host)
    {
      IJSRuntime? jsInterop =
        host.Services.GetRequiredService<IJSRuntime>();
      string? result =
        await jsInterop.InvokeAsync<string>("blazorCulture.get");

      CultureInfo culture;

      if (result != null)
      {
        culture = new CultureInfo(result);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
      }
    }
  }
}
