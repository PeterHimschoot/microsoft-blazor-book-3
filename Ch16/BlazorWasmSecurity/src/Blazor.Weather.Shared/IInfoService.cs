using System.Threading.Tasks;

namespace Blazor.Weather.Shared
{
  public interface IInfoService
  {
    ValueTask<InfoMessage> GetInfo();
  }
}
