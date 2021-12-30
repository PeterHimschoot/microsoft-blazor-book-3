using Bunit;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class CounterWithVCShould : TestContext
  {
    [Fact]
    public void ShouldUseCascadingIncrement()
    {
      IRenderedComponent<CounterWithCV>? cut = RenderComponent<CounterWithCV>(parameters =>
        parameters.AddCascadingValue("Increment", 3)
      );
      cut.Find(cssSelector: "button")
         .Click();
      cut.Find(cssSelector: "p")
         .MarkupMatches(@"<p>Current count: 3</p>");
    }
  }
}
