using System.Collections.Generic;
using System.Linq;

namespace Dependency.Inversion.Shared
{
  public class ProductsService : IProductsService
  {
    public IEnumerable<Product> GetProducts()
      => Enumerable.Repeat(new Product() {  Name = "Product", Description = "Some product", Price = 1M}, 10);
  }
}
