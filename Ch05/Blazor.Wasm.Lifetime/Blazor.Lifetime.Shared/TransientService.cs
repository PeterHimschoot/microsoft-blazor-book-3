using System;

namespace Blazor.LifeTime.Shared
{
  public class TransientService : IDisposable
  {
    public Guid Guid { get; set; } = Guid.NewGuid();

    public void Dispose() 
    => Console.WriteLine("TransientService Disposed");
  }
}
