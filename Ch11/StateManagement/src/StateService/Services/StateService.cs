using System.Collections.Generic;

namespace StateService.Services
{
  public class StateService<T>
  {
    private readonly Dictionary<string, T> counters
      = new Dictionary<string, T>();

    public T? GetState(string user)
    {
      if (this.counters.TryGetValue(user, out T? state))
      {
        return state;
      }
      return default;
    }

    public void SetState(string user, T state)
      => this.counters[user] = state;
  }
}
