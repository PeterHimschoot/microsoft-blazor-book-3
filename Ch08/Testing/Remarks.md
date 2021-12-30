# Remarks about Chapter 8

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Nullable reference types

The project already uses nullable reference types so ignore Listing 8-1.

## Testing Counter

Be careful, the `Counter` component now has some additional attributes.

## Injecting Dependencies with bUnit

The `UseWeatherService` test doesn't fail anymore, just continue...

##

The `ILogger` should be `ILogger<FetchData>`, 

### Listing 8-42:

``` C#
@inject ILogger<FetchData> logger
```

### Listing 8-43:

``` C#
private class LoggerMock : ILogger<FetchData>
```

### Listing 8-44:

``` C#
[Fact]
public void UseProperLogging()
{
  const int nrOfForecasts = 5;
  var stub = new WeatherServiceStub
  {
    FakeForecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts)
  };
  Services.AddSingleton<IWeatherService>(stub);
  LoggerMock logger = new LoggerMock();
  Services.AddSingleton<ILogger<FetchData>>(logger);

  var cut = RenderComponent<FetchData>();
  logger.Journal.Count.Should().Be(1);
  logger.Journal.First().state.Should().NotBeNull();
  logger.Journal.First().state!.ToString().Should().Contain("Fetching forecasts");
}
```

## The First Razor Test

Looks like I was a little tired here:

### Listing 8-48:

```
@inherits Bunit.TestContext

@code {

  [Fact]
  public void RenderCorrectlyWithInitialZero()
  {
    var cut = Render(@<Counter/>);
    cut.Find("p")
       .MarkupMatches(@<p role="status">Current count: 0</p>);
  }

  [Fact]
  public void IncrementCounterWhenButtonIsClicked()
  {
    var cut = Render(@<Counter/>);
    cut.Find(cssSelector: "button")
       .Click();
    cut.Find(cssSelector: "p")
       .MarkupMatches(@<p role="status">Current count: 1</p>);
  }
}
```







