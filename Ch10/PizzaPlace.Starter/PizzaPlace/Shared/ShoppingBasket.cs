// With implicit usings there is no need to add using statement
// for commonly used namespaces such as System.

namespace PizzaPlace.Shared;

public class ShoppingBasket
{
  public Customer Customer { get; set; } = new Customer();
  public List<int> Orders { get; set; } = new List<int>();
  public bool HasPaid { get; set; }
  public void Add(int pizzaId)
  => Orders.Add(pizzaId);
  public void RemoveAt(int pos)
 => Orders.RemoveAt(pos);
}
