using System.Threading.Tasks;

namespace JSInterop.Services
{
  public interface ILocalStorage
  {
    ValueTask Init();
    ValueTask<T> GetProperty<T>(string propName);
    ValueTask SetProperty<T>(string propName, T value);
    ValueTask WatchAsync<T>(T instance) where T : class;
  }
}
