using System.Collections.Generic;

namespace PizzaPlace.Shared
{
  public class Order
  {
    public int Id { get; set; }

    public Customer Customer { get; set; } = default!;

    public ICollection<Pizza> Pizzas { get; set; } = default!;
  }
}
