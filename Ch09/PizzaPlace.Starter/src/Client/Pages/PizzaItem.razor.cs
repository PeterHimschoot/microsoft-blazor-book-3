using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;

namespace PizzaPlace.Client.Pages
{
  public partial class PizzaItem
  {
    [Parameter]
    public Pizza Pizza { get; set; } = default!;

    [Parameter]
    public string ButtonTitle { get; set; } = default!;

    [Parameter]
    public string ButtonClass { get; set; } = default!;

    [Parameter]
    public EventCallback<Pizza> Selected { get; set; }

    private string SpicinessImage(Spiciness spiciness)
        => $"images/{spiciness.ToString().ToLower()}.png";
  }
}
