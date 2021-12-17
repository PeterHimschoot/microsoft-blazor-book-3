using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace JSInterop.Services
{
  public class LocalStorage : ILocalStorage
  {
    private readonly IJSRuntime js;

    public LocalStorage(IJSRuntime js)
    {
      this.js = js;
    }

    public ValueTask Init() => new ValueTask();

    public ValueTask<T> GetProperty<T>(string propName)
      => js.InvokeAsync<T>("blazorLocalStorage.get", propName);

    public ValueTask SetProperty<T>(string propName, T value)
      => js.InvokeVoidAsync("blazorLocalStorage.set", propName, value);

    public ValueTask WatchAsync<T>(T instance) where T : class
      => js.InvokeVoidAsync("blazorLocalStorage.watch",
                            DotNetObjectReference.Create(instance));
  }
}
