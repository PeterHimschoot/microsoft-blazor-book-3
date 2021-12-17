using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerializationOptions
{
  enum Weekday
  {
    Monday,
    Tuesday,
    Wednesday
  }

  class Demo
  {
    public string SomeProperty { get; set; }

    public Weekday Day { get; set; } = Weekday.Tuesday;
  }

  class Program
  {
    static void Main(string[] args)
    {
      JsonSerializerOptions options = new JsonSerializerOptions
      {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = {
          new JsonStringEnumConverter()
        }
      };

      Demo demo = new Demo
      {
        SomeProperty = "Demo"
      };

      string json = JsonSerializer.Serialize(demo);
      // string json = JsonSerializer.Serialize(demo, options);
      Console.WriteLine(json);
    }
  }
}
