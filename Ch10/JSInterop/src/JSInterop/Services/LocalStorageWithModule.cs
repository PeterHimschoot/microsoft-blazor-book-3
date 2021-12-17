using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace JSInterop.Services
{
  public class LocalStorageWithModule : ILocalStorage
  {
    private readonly IJSRuntime js;
    private IJSObjectReference? module;

    public LocalStorageWithModule(IJSRuntime js)
    {
      this.js = js;
    }

    public async ValueTask Init()
    {
      module = module ?? await js.InvokeAsync<IJSObjectReference>
        ("import", "./scripts/localstorage.js");
    }

    public ValueTask<T> GetProperty<T>(string propName)
      => module!.InvokeAsync<T>("get", propName);

    public ValueTask SetProperty<T>(string propName, T value)
      => module!.InvokeVoidAsync("set", propName, value);

    public ValueTask WatchAsync<T>(T instance) where T : class
      => module!.InvokeVoidAsync("watch",
                            DotNetObjectReference.Create(instance));
  }
}
