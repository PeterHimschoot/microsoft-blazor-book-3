using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Client.Pages
{
  public class AnimalComponent : ComponentBase
  {
    [Parameter]
    public EventCallback ValidSubmit { get; set; }
  }
}
