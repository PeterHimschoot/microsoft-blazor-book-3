using Fluxor;
using System;
using UsingRedux.Shared.Stores;

namespace UsingRedux.Shared.Features
{
  public class AppFeature : Feature<AppStore>
  {
    public override string GetName()
      => nameof(AppStore);

    protected override AppStore GetInitialState()
      => new AppStore(
           ClickCounter: 0,
           IsLoading: false,
           Forecasts: Array.Empty<WeatherForecast>()
        );
  }
}
