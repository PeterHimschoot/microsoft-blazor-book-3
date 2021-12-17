using Fluxor;
using Microsoft.AspNetCore.Components;
using UsingRedux.Shared.Actions;
using UsingRedux.Shared.Stores;

namespace UsingRedux.Client.Pages
{
  public partial class Counter
  {
    [Inject]
    public IState<AppStore> State { get; set; } = default!;

    [Inject]
    public IDispatcher Dispatcher { get; set; } = default!;

    public AppStore AppStore => State.Value;

    public void IncrementCounter()
    {
      var action = new IncrementCounterAction();
      Dispatcher.Dispatch(action);
    }

  }
}
