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
    //public Action<bool>? ShowChanged { get; set; }
    public EventCallback<bool> ShowChanged { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    public void Dismiss()
    => Show = false;
  }
}
