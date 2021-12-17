using System.Drawing;

namespace WhiteBoard.Shared
{
  public struct LineSegment
  {
    public LineSegment(PointF start, PointF end)
    {
      Start = start;
      End = end;
    }
    public PointF Start { get; set; }
    public PointF End { get; set; }
  }
}
