using Microsoft.AspNetCore.Components;
using StateManagementWASM.Services;
using System.Threading.Tasks;

namespace StateManagementWASM.Pages
{
  public partial class CounterState
  {
    [Inject]
    public StateService<int> counterStateService { get; set; } = default!;

    public int CurrentCount { get; set; }

    private async Task IncrementCount()
    {
      CurrentCount++;
      await counterStateService.SetState("peter", CurrentCount);

    }

    protected override async Task OnInitializedAsync()
    {
      int? state = await counterStateService.GetState("peter");
      if (state.HasValue)
      {
        CurrentCount = state.Value;
      }
    }
  }
}
