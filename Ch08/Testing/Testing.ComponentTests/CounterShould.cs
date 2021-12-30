using Bunit;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class CounterShould : TestContext
  {
    [Fact]
    public void RenderCorrectlyWithInitialZero()
    {
      IRenderedComponent<Counter>? cut = RenderComponent<Counter>();

      // You can use Assert.Equal, but this is way too sensitive about whitespace...
      //     Assert.Equal(@"
      //<h1>Counter</h1>
      //<p>Current count: 0</p>
      //<button class=""btn btn-primary"" >
      //Click me
      //</button>
      //", cut.Markup);

      // Better to use semantic comparison with MarkupMatches
      cut.MarkupMatches(@"
       <h1>Counter</h1>
       <p role=""status"">Current count: 0</p>
       <button class=""btn btn-primary"" >
       Click me
       </button>
       ");
    }

    [Fact]
    public void RenderParagraphCorrectlyWithInitialZero()
    {
      IRenderedComponent<Counter>? cut = RenderComponent<Counter>();
      cut.Find(cssSelector: "p")
      .MarkupMatches(@"<p role=""status"">Current count: 0</p>");
    }

    [Fact]
    public void IncrementCounterWhenButtonIsClicked()
    {
      IRenderedComponent<Counter>? cut = RenderComponent<Counter>();
      cut.Find(cssSelector: "button")
      .Click();
      cut.Find(cssSelector: "p")
      .MarkupMatches(@"<p role=""status"">Current count: 1</p>");
    }
  }
}
