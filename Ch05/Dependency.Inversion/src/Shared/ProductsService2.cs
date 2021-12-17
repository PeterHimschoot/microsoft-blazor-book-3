namespace Dependency.Inversion.Shared
{
  public class Dependency { }

  public class ProductsService2
  {
    private readonly Dependency dep;

    public ProductsService2(Dependency dep)
    {
      this.dep = dep;
    }
  }
}
