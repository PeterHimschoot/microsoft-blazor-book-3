using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteBoard.Shared;

namespace WhiteBoard.Client
{
  public partial class App : IAsyncDisposable
  {
    [Inject]
    public NavigationManager navigationManager { get; set; } = default!;

    private HubConnection hubConnection = default!;

    protected override async Task OnInitializedAsync()
    {
      this.hubConnection = new HubConnectionBuilder()
        .WithUrl(navigationManager.ToAbsoluteUri("/board"))
        .Build();

      this.hubConnection.On<IEnumerable<LineSegment>>("AddSegments",
        segments =>
        {
          this.LineSegments.AddRange(segments);
          StateHasChanged();
        });

      this.hubConnection.On<List<LineSegment>>("InitSegments",
        allSegments =>
        {
          Console.WriteLine($"InitLineSegments {allSegments.Count}");
          this.LineSegments.AddRange(allSegments);
          StateHasChanged();
        });

      await this.hubConnection.StartAsync();

      await this.hubConnection.SendAsync("GetAllSegments");
    }

    private readonly List<LineSegment> LineSegments = new List<LineSegment>();
    //{
    //  new LineSegment(new PointF(0,0), new Point(100,100)),
    //  new LineSegment(new PointF(100,100), new Point(100,200))
    //};

    private async Task AddLineSegment(LineSegment segment)
    {
      var segments = new List<LineSegment>() { segment };

      await this.hubConnection.SendAsync("SendSegments", segments);
      this.LineSegments.Add(segment);
    }

    public async ValueTask DisposeAsync()
    {
      if (this.hubConnection is not null)
      {
        await this.hubConnection.DisposeAsync();
      }
    }
  }
}
