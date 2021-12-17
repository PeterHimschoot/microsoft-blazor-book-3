using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
  public interface IMenuService
  {
    ValueTask<Menu> GetMenu();
  }
}
