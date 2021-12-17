using Microsoft.AspNetCore.Mvc;
using PizzaPlace.Shared;
using System.Collections.Generic;
using System.Linq;

namespace PizzaPlace.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PizzasController : ControllerBase
  {
    private readonly PizzaPlaceDbContext db;

    public PizzasController(PizzaPlaceDbContext db)
    {
      this.db = db;
    }

    [HttpGet("/pizzas")]
    public IQueryable<Pizza> GetPizzas()
      => db.Pizzas;

    [HttpPost("/pizzas")]
    public IActionResult InsertPizza([FromBody] Pizza pizza)
    {
      db.Pizzas.Add(pizza);
      db.SaveChanges();
      return Created($"pizzas/{pizza.Id}", pizza);
    }
  }
}
