# Remarks about Chapter 2

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## DismissibleAlert instead of Dismissible

On page 107 you should use `DismissableAlert`:

### Listing 3.7

```
@page "/"

<PageTitle>Index</PageTitle>

<h1>Hello, world!</h1>

<DismissibleAlert Show="@ShowAlert">
 <span class="oi oi-check mr-2" aria-hidden="true"></span>
 <strong>Blazor is so cool!</strong>
</DismissibleAlert>

<button @onclick="ToggleAlert" class="btn btn-success">Toggle</button>
@code {
  public bool ShowAlert { get; set; } = true;
  public void ToggleAlert() => ShowAlert = !ShowAlert;
}
```

## `EventCallBack<T>` does not need to be nullable

The book uses `EventCallBack<T>?` but it is better to simply use `EventCallBack<T>`. 

### Listing 3.14

```
using Microsoft.AspNetCore.Components;

namespace MyFirstBlazor.Client.Pages
{
  public partial class DismissibleAlert
  {
    private bool show;

    [Parameter]
    public bool Show
    {
      get => this.show;
      set
      {
        if (this.show != value)
        {
          this.show = value;
          ShowChanged.InvokeAsync(this.show);
        }
      }
    }

    [Parameter]
    public EventCallback<bool> ShowChanged { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    public void Dismiss()
    => Show = false;
  }
}
```

