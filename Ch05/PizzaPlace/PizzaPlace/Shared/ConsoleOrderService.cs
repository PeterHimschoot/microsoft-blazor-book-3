namespace PizzaPlace.Shared
{
  public class ConsoleOrderService : IOrderService
  {
    public ValueTask PlaceOrder(ShoppingBasket basket)
    {
      Console.WriteLine($"Placing order for {basket.Customer.Name}");
      // .NET 6 now has a CompletedTask which is better...
      return ValueTask.CompletedTask;
      //return new ValueTask();
    }
  }
}
