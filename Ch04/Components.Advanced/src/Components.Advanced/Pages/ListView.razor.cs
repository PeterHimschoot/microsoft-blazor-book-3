using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Components.Advanced.Pages
{
  public partial class ListView<TItem>
  {
    [Parameter]
    public RenderFragment<TItem> ItemTemplate { get; set; } = default!;

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;
  }
}
