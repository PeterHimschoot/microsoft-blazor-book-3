using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace MyFirstBlazor.Client.Pages
{
  public partial class LifeCycle
  {
    public LifeCycle()
    {
      Console.WriteLine("Inside constructor");
    }

    private int counter;

    [Parameter]
    public int Counter
    {
      get => counter;
      set
      {
        counter = value;
        Console.WriteLine($"Counter set to {counter}");
      }
    }

    // private bool firstParametersSet = true;

    public override Task SetParametersAsync(ParameterView parameters)
    {
      Console.WriteLine("SetParametersAsync called");

      shouldRender = true;
      if (parameters.TryGetValue(nameof(Counter), out int counter))
      {
        // ignore odd values
        if (counter % 2 == 0)
        {
          shouldRender = false;
        }
      }
      return base.SetParametersAsync(parameters);
    }

    private bool shouldRender;

    protected override bool ShouldRender()
    {
      Console.WriteLine($"ShouldRender called");
      return shouldRender;
    }

    DateTime lastUpdate;

    protected override void OnParametersSet()
    {
      lastUpdate = DateTime.Now;
      Console.WriteLine("OnParametersSet called");
    }

    protected override async Task OnParametersSetAsync()
    {
      Console.WriteLine("OnParametersSetAsync called");
      await Task.Delay(1000);
      Console.WriteLine("OnParametersSetAsync completed");
    }

    DateTime created; 

    protected override void OnInitialized()
    {
      created = DateTime.Now;
      Console.WriteLine("OnInitialized called");
    }

    protected override Task OnInitializedAsync()
    {
      Console.WriteLine("OnInitializedAsync called");
      return Task.CompletedTask;
    }

    protected override void OnAfterRender(bool firstRender)
      => Console.WriteLine($"OnAfterRender called with firstRender = {firstRender}");

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      Console.WriteLine($"OnAfterRenderAsync called with firstRender = {firstRender}");
      return Task.CompletedTask;
    }

    public void Dispose()
      => Console.WriteLine("Disposed");
  }
}
