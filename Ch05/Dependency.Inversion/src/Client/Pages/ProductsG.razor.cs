using Dependency.Inversion.Shared;
using Microsoft.AspNetCore.Components;

namespace Dependency.Inversion.Client.Pages
{
  public partial class ProductsG
  {
    [Inject]
    public IProductsService ProductsService { get; set; } = default!;
  }
}
