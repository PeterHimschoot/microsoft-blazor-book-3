using Components.Advanced.Client.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Advanced.Client.Data
{
  public static class AnimalMetaData
  {
    private static Dictionary<string, object> ToParameters(this object instance)
      => new Dictionary<string, object>
         {
           { "Instance", instance }
         };

    public static ComponentMetaData? ToMetaData(this AnimalKind animal)
    => animal switch
    {
      AnimalKind.Dog => new ComponentMetaData(typeof(DogComponent), new Dog().ToParameters()),
      AnimalKind.Cat => new ComponentMetaData(typeof(CatComponent), new Cat().ToParameters()),
      _ => null
    };
  }
}
