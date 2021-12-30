using Bunit;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using System.Data;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class AlertShould : TestContext
  {
    [Fact]
    public void RenderSimpleChildContent()
    {
      var cut = RenderComponent<Alert>(parameters =>
      parameters.AddChildContent("<p>Hello world!</p>"));
      cut.MarkupMatches(@"
        <div class=""alert alert-secondary mt-4"" role=""alert"">
            <p>Hello world!</p>
        </div>
      ");
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
