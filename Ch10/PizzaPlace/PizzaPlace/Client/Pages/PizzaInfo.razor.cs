using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;

namespace PizzaPlace.Client.Pages
{
  public partial class PizzaInfo
  {
    [Inject]
    public State State { get; set; } = default!;

    public Pizza CurrentPizza 
      => State.CurrentPizza!;

    private string SpicinessImage(Spiciness spiciness)
      => $"images/{spiciness.ToString().ToLower()}.png";
  }
}
