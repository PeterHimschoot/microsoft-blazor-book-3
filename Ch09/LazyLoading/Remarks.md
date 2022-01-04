# Remarks about Chapter 9

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Lazy Loading on page 373

Don't forget to remove the `LazyLoading.Library` from the `additionalAssemblies`.
This is correct in the book, but many will forget this

``` C#
  private List<Assembly> additionalAssemblies =
     new List<Assembly> { /* typeof(Counter).Assembly */ };
```

## Using IWeatherServiceFactory

Don't forget to update dependency injection to use `IWeatherServiceFactory`.

``` C#
using LazyLoading.Client;
using LazyLoading.Client.Services;
using LazyLoading.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IWeatherServiceFactory, WeatherServiceFactory>();

builder.Services.AddScoped<LazyAssemblyLoader>();

await builder.Build().RunAsync();
```





