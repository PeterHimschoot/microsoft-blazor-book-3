using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Advanced.Client.Pages
{
  public partial class ListView<TItem>
  {
    [Parameter]
    public RenderFragment<TItem> ItemTemplate { get; set; } = default!;
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; } = default!;
  }
}
