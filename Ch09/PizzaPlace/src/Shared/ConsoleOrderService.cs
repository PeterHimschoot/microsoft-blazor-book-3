using System;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
  public class ConsoleOrderService : IOrderService
  {
    public ValueTask PlaceOrder(ShoppingBasket basket)
    {
      Console.WriteLine($"Placing order for {basket.Customer.Name}");
      return new ValueTask();
    }
  }
}
