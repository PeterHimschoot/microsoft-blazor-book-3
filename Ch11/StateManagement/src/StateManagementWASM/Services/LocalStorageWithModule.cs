using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace JSInterop.Services
{
  public class LocalStorageWithModule : ILocalStorage
  {
    private readonly IJSRuntime js;
    private IJSObjectReference? module;

    public LocalStorageWithModule(IJSRuntime js) => this.js = js;

    public async ValueTask Init()
      => this.module = this.module ?? await this.js.InvokeAsync<IJSObjectReference>
        ("import", "./scripts/localstorage.js");

    public ValueTask<T> GetProperty<T>(string propName)
      => this.module!.InvokeAsync<T>("get", propName);

    public ValueTask SetProperty<T>(string propName, T value)
      => this.module!.InvokeVoidAsync("set", propName, value);

    public ValueTask WatchAsync<T>(T instance) where T : class
      => this.module!.InvokeVoidAsync("watch",
                            DotNetObjectReference.Create(instance));
  }
}
