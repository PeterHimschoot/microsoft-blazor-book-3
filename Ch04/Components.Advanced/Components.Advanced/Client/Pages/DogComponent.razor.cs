using Components.Advanced.Client.Data;
using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Client.Pages
{
  public partial class DogComponent
  {
    [Parameter]
    public Dog Instance { get; set; } = default!;
  }
}
