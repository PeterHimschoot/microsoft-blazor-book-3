using System;
using System.Threading.Tasks;

namespace Blazor.Weather.Shared
{
  public interface IWeatherForecastService
  {
    ValueTask<WeatherForecast[]> GetForecastAsync(DateTime startDate);
  }
}
