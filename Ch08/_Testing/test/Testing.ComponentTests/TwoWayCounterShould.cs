using Bunit;
using FluentAssertions;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class TwoWayCounterShould : TestContext
  {
    [Fact]
    public void IncrementCounterWhenClicked()
    {
      var cut = RenderComponent<TwoWayCounter>(
        parameters =>
            parameters.Add(counter => counter.CurrentCount, 0)
                      .Add(counter => counter.Increment, 1)
          );

      cut.Find("button").Click();

      cut.Find("p")
         .MarkupMatches("<p>Current count: 1</p>");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(-3)]
    public void IncrementCounterWithIncrementWhenClicked(int increment)
    {
      var cut = RenderComponent<TwoWayCounter>(
            ("CurrentCount", 0),
            ("Increment", increment)
          );
      cut.Find("button").Click();
      cut.Find("p")
         .MarkupMatches($"<p>Current count: {increment}</p>");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(-3)]
    public void IncrementCounterWithIncrementWhenClickedWithNameOf(int increment)
    {
      var cut = RenderComponent<TwoWayCounter>(
            (nameof(TwoWayCounter.CurrentCount), 0),
            (nameof(TwoWayCounter.Increment), increment)
          );
      cut.Find("button").Click();
      cut.Find("p")
         .MarkupMatches($"<p>Current count: {increment}</p>");
    }

    [Fact]
    public void TriggerChangedEventForCurrentCounter()
    {
      int nrOfCurrentCountChanged = 0;
      int nrOfIncrementChanged = 0;

      var cut = RenderComponent<TwoWayCounter>(parameters =>
            parameters.Add(counter => counter.CurrentCount, 0)
                      .Add(counter => counter.Increment, 1)
                      .Add(counter => counter.CurrentCountChanged, 
                        () => nrOfCurrentCountChanged++)
                      .Add(counter => counter.IncrementChanged, 
                        () => nrOfIncrementChanged++)
                      );
      cut.Find("button").Click();
      cut.Instance.Increment = 2;
      nrOfCurrentCountChanged.Should().Be(1);
      nrOfIncrementChanged.Should().Be(1);
    }

    [Fact]
    public void TriggerChangedEventForCurrentCounter2()
    {
      int nrOfIncrementChanged = 0;
      var cut = RenderComponent<TwoWayCounter>(parameters =>
            parameters.Add(counter => counter.CurrentCount, 0)
                      .Add(counter => counter.Increment, 1)
                      .Add(counter => counter.IncrementChanged, 
                        () => nrOfIncrementChanged++)
                      );
      cut.SetParametersAndRender(parameters =>
        parameters.Add(counter => counter.Increment, 2));
      nrOfIncrementChanged.Should().Be(1);
    }
  }
}
