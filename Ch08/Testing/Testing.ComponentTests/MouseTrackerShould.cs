using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Testing.Client.Pages;
using Xunit;

namespace Testing.ComponentTests
{
  public class MouseTrackerShould : TestContext
  {
    [Fact]
    public void ShowCorrectMousePosition()
    {
      var eventArgs = new MouseEventArgs()
      {
        ClientX = 100,
        ClientY = 200
      };
      IRenderedComponent<MouseTracker>? cut = RenderComponent<MouseTracker>();
      AngleSharp.Dom.IElement? theDiv = cut.Find(cssSelector: "div");
      theDiv.MouseMove(eventArgs);
      theDiv.MarkupMatches($"<div style:ignore>Mouse at {eventArgs.ClientX}x{eventArgs.ClientY}");
    }
  }
}
