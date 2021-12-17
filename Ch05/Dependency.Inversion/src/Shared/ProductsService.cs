using System.Collections.Generic;
using System.Linq;

namespace Dependency.Inversion.Shared
{
  public class ProductsService : IProductsService
  {
    public IEnumerable<Product> GetProducts()
      => Enumerable.Repeat(new Product(), 10);
  }
}
