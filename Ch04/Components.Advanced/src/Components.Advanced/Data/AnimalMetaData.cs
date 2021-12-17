using Components.Advanced.Pages;
using System.Collections.Generic;

namespace Components.Advanced.Data
{
  public static class AnimalMetaData
  {
    private static Dictionary<string, object> ToParameters(this object instance)
      => new Dictionary<string, object> { { "Instance", instance } };

    public static ComponentMetaData? ToMetaData(this AnimalKind animal)
    => animal switch
    {
      AnimalKind.Dog => new ComponentMetaData(typeof(DogComponent), new Dog().ToParameters()),
      AnimalKind.Cat => new ComponentMetaData(typeof(CatComponent), new Cat().ToParameters()),
      _ => null
    };
  }
}
