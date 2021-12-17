using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteBoard.Shared;

namespace WhiteBoard.Server.Hubs
{
  public class BoardHub : Hub
  {
    private static readonly List<LineSegment> allSegments = new List<LineSegment>();
    private readonly ILogger<BoardHub> logger;

    public BoardHub(ILogger<BoardHub> logger) => this.logger = logger;

    public async Task GetAllSegments()
    {
      this.logger.LogInformation($"{nameof(GetAllSegments)} - {allSegments.Count}");
      await Clients.Caller.SendAsync("InitSegments", allSegments);
    }

    public async Task SendSegments(IEnumerable<LineSegment> segments)
    {
      this.logger.LogInformation(nameof(SendSegments));
      allSegments.AddRange(segments);
      await Clients.Others.SendAsync("AddSegments", segments);
    }
  }
}
