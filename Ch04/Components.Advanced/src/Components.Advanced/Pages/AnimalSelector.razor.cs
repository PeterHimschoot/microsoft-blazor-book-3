using Components.Advanced.Data;
using System;

namespace Components.Advanced.Pages
{
  public partial class AnimalSelector
  {
    ComponentMetaData? MetaData;

    private void AnimalSelected(object? value)
    {
      string? val = value?.ToString();
      if (Enum.TryParse<AnimalKind>(val, out AnimalKind kind))
      {
        MetaData = kind.ToMetaData();
      }
    }
  }
}
