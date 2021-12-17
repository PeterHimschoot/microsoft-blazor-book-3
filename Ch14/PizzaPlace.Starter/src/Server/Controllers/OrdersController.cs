using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly PizzaPlaceDbContext db;

    public OrdersController(PizzaPlaceDbContext db)
    {
      this.db = db;
    }

    [HttpPost("/orders")]
    public IActionResult InsertOrder([FromBody] ShoppingBasket basket)
    {
      Order order = new Order();
      order.Customer = basket.Customer;
      order.Pizzas = new List<Pizza>();
      foreach (int pizzaId in basket.Orders)
      {
        var pizza = db.Pizzas.Single(p => p.Id == pizzaId);
        order.Pizzas.Add(pizza);
      }

      db.Orders.Add(order);
      db.SaveChanges();
      return Created("/orders", order.Id);
    }
  }
}
