using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Components.Library
{
  public partial class ListView2<TItem>
  {
    [Parameter]
    public RenderFragment<RenderFragment>? ListTemplate { get; set; }

    [Parameter]
    public RenderFragment<TItem> ItemTemplate { get; set; } = default!;

    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;
  }
}
