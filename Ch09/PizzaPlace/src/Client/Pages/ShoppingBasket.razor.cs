using Microsoft.AspNetCore.Components;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.Client.Pages
{
  public partial class ShoppingBasket
  {
    [Parameter]
    public IEnumerable<int> Orders { get; set; } = default!;

    [Parameter]
    public EventCallback<int> Selected { get; set; } = default!;

    [Parameter]
    public Func<int, Pizza> GetPizzaFromId { get; set; } = default!;

    private IEnumerable<(Pizza pizza, int pos)> Pizzas { get; set; } = default!;

    private decimal TotalPrice { get; set; } = default!;

    protected override void OnParametersSet()
    {
      Pizzas = Orders.Select((id, pos)
                 => (pizza: GetPizzaFromId(id), pos: pos));
      TotalPrice = Pizzas.Select(tuple
                     => tuple.pizza.Price).Sum();
    }
  }
}
