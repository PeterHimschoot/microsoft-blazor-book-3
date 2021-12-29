# Remarks about Chapter 5

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Dependency Injection and Blazor Server

Blazor Server in .NET 6 now uses the same syntax as Blazor WebAssembly

``` C#
using Blazor.LifeTime.Shared;
using Blazor.Server.Lifetime.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddScoped<ScopedService>();

var app = builder.Build();
```

## OwningComponent

For Blazor.Lifetime.Server look in the console which is 
hosting the project, not in the browser's console to see 
the `ScopedService` being disposed.








