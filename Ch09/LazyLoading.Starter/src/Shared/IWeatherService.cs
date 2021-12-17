using System.Collections.Generic;
using System.Threading.Tasks;

namespace LazyLoading.Shared
{
  public interface IWeatherService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecasts();
  }
}
