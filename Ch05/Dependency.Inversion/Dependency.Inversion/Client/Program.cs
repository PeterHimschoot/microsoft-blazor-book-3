using Dependency.Inversion.Client;
using Dependency.Inversion.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
       .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Tell dependency injection to create a singleton ProductService
builder.Services
       .AddSingleton<IProductsService, ProductsService>();

// Create the ProductsService singleton and tell dependency injection to use that instance
//ProductsService productsService = new ProductsService();
//builder.Services
//       .AddSingleton<IProductsService>(productsService);

// Use ProductService as a singleton without using an interface
//builder.Services
//       .AddSingleton<ProductsService>();

// Tell dependency injection to create a new instance of ProductService every time
//builder.Services
//       .AddTransient<IProductsService, ProductsService>();

// Tell dependency injection to create a new instance of ProductService for each scope
//builder.Services
//       .AddScoped<IProductsService, ProductsService>();

// Use ProductService as a scoped instance without using an interface
//builder.Services
//       .AddScoped<ProductsService>();

await builder.Build().RunAsync();
