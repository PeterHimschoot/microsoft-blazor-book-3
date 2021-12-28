namespace Components.Advanced.Client.Data
{
  public class ComponentMetaData
  {
    public ComponentMetaData(Type type, Dictionary<string, object> parameters)
    {
      Type = type;
      Parameters = parameters;
    }

    public Type Type { get; set; }

    public Dictionary<string, object> Parameters { get; }
  }
}
