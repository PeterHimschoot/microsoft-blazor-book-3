using Blazor.Weather.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorWasm.Client.Pages
{
  // [Authorize(Roles="admin")]
  [Authorize(Policy=Policies.RoleAndCountry)]
  public partial class FetchData
  {
    [Inject]
    public IWeatherForecastService WeatherForecastService { get; set; }

    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
      forecasts = await WeatherForecastService.GetForecastAsync(DateTime.Now);
    }

  }
}
