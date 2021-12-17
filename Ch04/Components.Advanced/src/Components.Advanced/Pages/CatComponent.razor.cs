using Components.Advanced.Data;
using Microsoft.AspNetCore.Components;

namespace Components.Advanced.Pages
{
  public partial class CatComponent
  {
    [Parameter]
    public Cat Instance { get; set; } = default!;
  }
}
