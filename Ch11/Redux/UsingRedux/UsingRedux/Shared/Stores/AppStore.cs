namespace UsingRedux.Shared.Stores
{
  // AppStore is an immutable reference type!
  public record AppStore(
    int ClickCounter,
    bool IsLoading,
    WeatherForecast[]? Forecasts
    );
}
