using Components.Advanced.Data;
using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Pages
{
  public partial class AnimalComponent : ComponentBase
  {
    [Parameter]
    public EventCallback ValidSubmit { get; set; }

  }
}
