using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class CounterWithVCShould : TestContext
  {
    [Fact]
    public void ShouldUseCascadingIncrement()
    {
      var cut = RenderComponent<CounterWithCV>(parameters =>
        parameters.AddCascadingValue("Increment", 3));
      cut.Find(cssSelector: "button")
         .Click();
      cut.Find(cssSelector: "p")
         .MarkupMatches(@"<p>Current count: 3</p>");
    }
  }
}
