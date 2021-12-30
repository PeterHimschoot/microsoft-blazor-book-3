using Microsoft.AspNetCore.Components.Web;

namespace Testing.Client.Pages
{
  public partial class MouseTracker
  {
    private string pos = "";

    private void MouseMove(MouseEventArgs e)
      => pos = $"Mouse at {e.ClientX}x{e.ClientY}";
  }
}
