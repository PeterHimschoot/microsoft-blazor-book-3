using System;

namespace Blazor.LifeTime.Shared
{
  public class SingletonService : IDisposable
  {
    public Guid Guid { get; set; } = Guid.NewGuid();

    public void Dispose() 
    => Console.WriteLine("SingletonService Disposed");
  }
}
