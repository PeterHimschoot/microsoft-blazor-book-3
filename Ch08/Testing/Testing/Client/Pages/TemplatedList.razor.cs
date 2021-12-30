using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Testing.Client.Pages
{
  public partial class TemplatedList<TItem>
  {
    IEnumerable<TItem>? items;

    [Parameter]
    public Func<ValueTask<IEnumerable<TItem>?>>? Loader { get; set; }

    [Parameter]
    public RenderFragment LoadingContent { get; set; } = default!;

    [Parameter]
    public RenderFragment? EmptyContent { get; set; } = default!;

    [Parameter]
    public RenderFragment<TItem> ItemContent { get; set; } = default!;

    [Parameter] 
    public string ListGroupClass { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
      if (Loader is not null)
      {
        items = await Loader();
      }
    }
  }
}
