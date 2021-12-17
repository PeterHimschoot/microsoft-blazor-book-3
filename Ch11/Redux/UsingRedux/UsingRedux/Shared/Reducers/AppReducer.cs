using Fluxor;
using UsingRedux.Shared.Actions;
using UsingRedux.Shared.Stores;

namespace UsingRedux.Shared.Reducers
{
  public static class AppReducer
  {
    [ReducerMethod]
    public static AppStore ReduceIncrementCounterAction
      (AppStore state, IncrementCounterAction action)
    => state with { ClickCounter = state.ClickCounter + 1 };

    [ReducerMethod]
    public static AppStore ReduceFetchDataAction
      (AppStore state, FetchDataAction action)
      => state with { IsLoading = true };

    [ReducerMethod]
    public static AppStore ReduceFetchDataResultAction
      (AppStore state, FetchDataResultAction action)
      => state with { IsLoading = false, Forecasts = action.Forecasts };
  }
}
