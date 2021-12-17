using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace PizzaPlace.Client.Pages
{
  public class InputWatcher : ComponentBase
  {
    private EditContext editContext = default!;

    [CascadingParameter]
    public EditContext EditContext
    {
      get => this.editContext;
      set
      {
        this.editContext = value;
        EditContext.OnFieldChanged += async (sender, e) =>
        {
          await FieldChanged.InvokeAsync(e.FieldIdentifier.FieldName);
        };
      }
    }

    [Parameter]
    public EventCallback<string> FieldChanged { get; set; }

    public bool Validate()
      => EditContext?.Validate() ?? false;
  }
}
