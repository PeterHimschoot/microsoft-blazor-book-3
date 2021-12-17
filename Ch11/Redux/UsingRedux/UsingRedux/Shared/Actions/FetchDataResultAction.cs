namespace UsingRedux.Shared.Actions
{
  public class FetchDataResultAction
  {
    public WeatherForecast[]? Forecasts { get; }

    public FetchDataResultAction(WeatherForecast[]? forecasts)
      => Forecasts = forecasts;
  }
}
