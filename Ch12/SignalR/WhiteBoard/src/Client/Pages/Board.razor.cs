using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WhiteBoard.Shared;

namespace WhiteBoard.Client.Pages
{
  public enum MouseButton
  {
    Left, Middle, Right
  }

  public partial class Board
  {
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public List<LineSegment> LineSegments { get; set; } = default!;

    [Parameter]
    public Func<LineSegment, Task> AddSegment { get; set; } = default!;

    public ElementReference board = default!;

    private IJSObjectReference? canvas = default;

    protected override async Task OnInitializedAsync()
    {
      this.canvas =
        await JSRuntime.InvokeAsync<IJSObjectReference>
        ("import", "./scripts/canvas.js");
      await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (this.canvas is not null)
      {
        Console.WriteLine($"Drawing {LineSegments.Count()}");
        await this.canvas
          .InvokeVoidAsync("drawLines", this.board, LineSegments);
      }
    }

    private PointF lastPos = new PointF(0, 0);
    private DateTime lastEvent;
    private bool trackMouse = false;

    private void MouseDown(MouseEventArgs e)
    {
      if (e.Button == (int)MouseButton.Left)
      {
        this.trackMouse = true;
        this.lastPos = new PointF((float)e.ClientX, (float)e.ClientY);
      }
    }

    private void MouseUp(MouseEventArgs e) => this.trackMouse = false;

    private void MouseMove(MouseEventArgs e)
    {
      var currentPos = new PointF((float)e.ClientX, (float)e.ClientY);
      DateTime currentEvent = DateTime.Now;
      TimeSpan time = currentEvent - this.lastEvent;
      if (this.trackMouse && time.TotalMilliseconds > 200)
      {
        AddSegment.Invoke(new LineSegment(this.lastPos, currentPos));
        this.lastEvent = currentEvent;
        this.lastPos = currentPos;
        //Console.WriteLine($"{currentPos}");
      }
    }
  }
}
