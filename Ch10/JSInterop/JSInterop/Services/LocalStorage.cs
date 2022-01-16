using Microsoft.JSInterop;

namespace JSInterop.Services
{
  public class LocalStorage : ILocalStorage
  {
    private readonly IJSRuntime js;
    public LocalStorage(IJSRuntime js) => this.js = js;
    public ValueTask Init() => ValueTask.CompletedTask; // new in .NET 6
    public ValueTask<T> GetProperty<T>(string propName)
    => this.js.InvokeAsync<T>("blazorLocalStorage.get", propName);
    public ValueTask SetProperty<T>(string propName, T value)
    => this.js.InvokeVoidAsync("blazorLocalStorage.set", propName, value);
    public ValueTask WatchAsync<T>(T instance) where T : class
    => this.js.InvokeVoidAsync("blazorLocalStorage.watch", DotNetObjectReference.Create(instance));
  }
}
