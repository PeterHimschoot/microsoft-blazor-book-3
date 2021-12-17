using System.Collections.Generic;

namespace Dependency.Inversion.Shared
{
  public interface IProductsService
  {
    IEnumerable<Product> GetProducts();
  }
}