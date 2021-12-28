using Components.Advanced.Client.Data;
using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Client.Pages
{
  public partial class CatComponent
  {
    [Parameter]
    public Cat Instance { get; set; } = default!;
  }
}
