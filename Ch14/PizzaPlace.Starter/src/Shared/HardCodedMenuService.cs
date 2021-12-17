using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
  public class HardCodedMenuService : IMenuService
  {
    public ValueTask<Menu> GetMenu()
      => new ValueTask<Menu>(
        new Menu
        {
          Pizzas = new List<Pizza> {
            new Pizza(1, "Pepperoni", 8.99M, Spiciness.Spicy),
            new Pizza(2, "Margarita", 7.99M, Spiciness.None),
            new Pizza(3, "Diabolo", 9.99M, Spiciness.Hot)
          }
        });
  }
}
