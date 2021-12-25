using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBlazor.Client.Pages
{
  public class Timer : ComponentBase
  {
    [Parameter]
    public double TimeInSeconds { get; set; }

    [Parameter]
    public EventCallback Tick { get; set; } = default!;

    protected override void OnInitialized()
    {
      var timer = new System.Threading.Timer(callback: 
        (_) => InvokeAsync(async () => await Tick.InvokeAsync()),
      state: null,
      dueTime: TimeSpan.FromSeconds(TimeInSeconds),
      period: Timeout.InfiniteTimeSpan);
    }
  }
}
