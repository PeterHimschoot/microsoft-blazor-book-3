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
  public class AlertShould : TestContext
  {
    [Fact]
    public void RenderSimpleChildContent()
    {
      var cut = RenderComponent<Alert>(parameters => parameters.AddChildContent("<p>Hello world!</p>"));
      cut.MarkupMatches(@"
        <div class=""alert alert-secondary mt-4"" role=""alert"">
        <p>Hello world!</p>
        </div>");
    }

    [Fact]
    public void RenderCounterAsChildContent()
    {
      var cut = RenderComponent<Alert>(parameters => parameters.AddChildContent<Counter>());
      var p = cut.Find("p");
      p.MarkupMatches(@"<p role=""status"">Current count: 0</p>");
    }

    [Fact]
    public void RenderTwoWayCounterWithParametersAsChildContent()
    {
      var cut = RenderComponent<Alert>(parameters =>
        parameters.AddChildContent<TwoWayCounter>(parameters =>
          parameters.Add(counter => counter.CurrentCount, 3)
        )
      );
      var p = cut.Find("p");
      p.MarkupMatches("<p>Current count: 3</p>");
    }

    [Fact]
    public void RenderTitleAndCounterAsChildContent()
    {
      const string header = "<h1>This is a counter</h1>";
      var cut = RenderComponent<Alert>(parameters =>
      parameters.AddChildContent(header)
      .AddChildContent<Counter>());
      var h1 = cut.Find("h1");
      h1.MarkupMatches(header);
      var p = cut.Find("p");
      p.MarkupMatches(@"<p role=""status"">Current count: 0</p>");
    }

    [Fact]
    public void RenderCorrectly()
    {
      var cut = RenderComponent<Alert>(parameters =>
      parameters.AddChildContent("<p>Hello world!</p>"));
      cut.MarkupMatches(@"
        <div class=""alert alert-secondary mt-4"" role=""alert"">
        <p diff:ignore></p>
        </div>
      ");
    }
  }
}
