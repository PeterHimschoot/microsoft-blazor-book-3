using Components.Advanced.Data;
using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Pages
{
  public partial class DogComponent
  {
    [Parameter]
    public Dog Instance { get; set; } = default!;
  }
}
