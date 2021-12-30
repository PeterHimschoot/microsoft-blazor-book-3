using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Client.Pages;
using Testing.Shared;
using Xunit;

namespace Testing.ComponentTests
{
  public class FetchDataShould : TestContext
  {

    private class WeatherServiceStub : IWeatherService
    {
      public IEnumerable<WeatherForecast>? FakeForecasts { get; set; } = default!;

      public ValueTask<IEnumerable<WeatherForecast>?> GetForecasts()
      => new ValueTask<IEnumerable<WeatherForecast>?>(FakeForecasts);
    }

    private class LoggerMock : ILogger<FetchData>
    {
      public List<(LogLevel logLevel, object? state)> Journal { get; set; } = new List<(LogLevel, object?)>();

      public IDisposable BeginScope<TState>(TState state) => throw new NotImplementedException();

      public bool IsEnabled(LogLevel logLevel) => true;

      public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
      {
        Journal.Add((logLevel, state));
      }
    }

    //[Fact]
    //public void UseWeatherService()
    //{
    //  // Use Services for dependency injection
    //  Services.AddSingleton<IWeatherService, Testing.Shared.WeatherService>();
    //  var cut = RenderComponent<FetchData>();
    //  var rows = cut.FindAll("tbody tr");
    //  rows.Count.Should().Be(5);
    //}

    [Fact]
    public void UseWeatherService()
    {
      const int nrOfForecasts = 5;
      var stub = new WeatherServiceStub
      {
        FakeForecasts = Enumerable.Repeat(new WeatherForecast(),
      nrOfForecasts)
      };
      Services.AddSingleton<IWeatherService>(stub);
      var cut = RenderComponent<FetchData>();
      var rows = cut.FindAll("tbody tr");
      rows.Count.Should().Be(nrOfForecasts);
    }

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

    [Fact]
    public void UseWeatherServiceMOQ()
    {
      const int nrOfForecasts = 5;
      var forecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts);
      Mock<IWeatherService> stub = new Mock<IWeatherService>();
      stub.Setup(s => s.GetForecasts())
          .Returns(new ValueTask<IEnumerable<WeatherForecast>?>(forecasts));
      Services.AddSingleton<IWeatherService>(stub.Object);
      Mock<ILogger<FetchData>> loggerStub = new Mock<ILogger<FetchData>>();
      Services.AddSingleton<ILogger>(loggerStub.Object);
      var cut = RenderComponent<FetchData>();
      var rows = cut.FindAll("tbody tr");
      rows.Count.Should().Be(nrOfForecasts);
    }

    [Fact]
    public void UseProperLoggingMOQ()
    {
      const int nrOfForecasts = 5;
      var forecasts = Enumerable.Repeat(new WeatherForecast(), nrOfForecasts);
      Mock<IWeatherService> stub = new Mock<IWeatherService>();
      stub.Setup(s => s.GetForecasts())
          .Returns(new ValueTask<IEnumerable<WeatherForecast>?>(forecasts));
      Services.AddSingleton<IWeatherService>(stub.Object);
      Mock<ILogger<FetchData>> loggerMock = new Mock<ILogger<FetchData>>();
      Services.AddSingleton<ILogger<FetchData>>(loggerMock.Object);
      var cut = RenderComponent<FetchData>();
      loggerMock.Verify(
        l => l.Log(
          It.Is<LogLevel>(l => l == LogLevel.Information),
          It.IsAny<EventId>(),
          It.Is<It.IsAnyType>((msg, t) => msg.ToString()!.Contains("Fetching forecasts")),
          It.IsAny<Exception>(),
          It.Is<Func<It.IsAnyType, Exception?, string>>((v, t) => true))
        , Times.Once
      );
    }
  }
}
