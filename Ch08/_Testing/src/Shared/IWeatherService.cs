using System.Collections.Generic;
using System.Threading.Tasks;

namespace Testing.Shared
{
  public interface IWeatherService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecasts();
  }
}
