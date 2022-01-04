// With implicit usings there is no need to add using statement
// for commonly used namespaces such as System.

namespace PizzaPlace.Shared;

public class Menu
{
  public List<Pizza> Pizzas { get; set; }
  = new List<Pizza>();
  public void Add(Pizza pizza)
  => Pizzas.Add(pizza);
  public Pizza? GetPizza(int id)
  => Pizzas.SingleOrDefault(pizza => pizza.Id == id);
}
