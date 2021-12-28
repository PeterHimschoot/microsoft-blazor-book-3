# Remarks about Chapter 4

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## ErrorBoundary

When you uses a hosted Blazor WASM project, the `WeatherForecast` class 
throws an exception, which "crashes" serialization.

Fix this by telling the JSON serializer to ignore this property:

``` C#
public class WeatherForecast
{
  public DateTime Date { get; set; }

  public int TemperatureC { get; set; }

  public string? Summary { get; set; }

  [JsonIgnore]
  public int TemperatureF
    => TemperatureC > 0 ? 32 + (int)(TemperatureC / 0.5556)
                        : throw new DivideByZeroException();
}
```

## Building a Component Library

No need to set the nullable option for the project. Already there.

## Dynamic Components

Blazor with .NET 6 now uses bootstrap 5 by default, so update the class for label and input:

``` html
<label class="col-2 form-check-label" for="scratches">Is a good dog</label>
<div class="col-1 pl-0 w-auto">
  <InputCheckbox class="form-check-input col-6"
                 @bind-Value="@Instance.IsAGoodDog" />
</div>
```





