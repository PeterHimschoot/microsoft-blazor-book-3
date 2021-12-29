# Remarks about Chapter 6

This file uses [Markdown](https://www.wikipedia.org/wiki/Markdown)

## Preparing Your Project for Code-First Migrations

In .NET 6 the template uses minimal API so things look a little different:

### Listing 6-6

``` C#
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();
```

### Listing 6-7

This is gone...

### Listing 6-8

``` C#
using Microsoft.EntityFrameworkCore;
using PizzaPlace.Server;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PizzaPlaceDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("PizzaPlaceDb")));

var app = builder.Build();
```

## Creating your first Code-First Migration

Dependening on your setup you might also need to install NuGet package `Microsoft.EntityFrameworkCore.Design`


