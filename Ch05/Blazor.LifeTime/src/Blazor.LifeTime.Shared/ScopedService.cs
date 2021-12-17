using System;

namespace Blazor.LifeTime.Shared
{
  public class ScopedService : IDisposable
  {
    public Guid Guid { get; set; } = Guid.NewGuid();

    public void Dispose()
      => Console.WriteLine(" *** ScopedService Disposed");
  }
}
