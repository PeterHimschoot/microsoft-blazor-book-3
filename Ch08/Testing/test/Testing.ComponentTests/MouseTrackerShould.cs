using Bunit;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
      var cut = RenderComponent<MouseTracker>();

      var theDiv = cut.Find(cssSelector: "div");
      theDiv.MouseMove(eventArgs);

      theDiv.MarkupMatches($"<div style:ignore>Mouse at {eventArgs.ClientX}x{eventArgs.ClientY}");
    }
  }
}
