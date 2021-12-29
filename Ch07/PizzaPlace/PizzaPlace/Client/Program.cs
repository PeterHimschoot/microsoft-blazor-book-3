using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaPlace.Client;
using PizzaPlace.Client.Services;
using PizzaPlace.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services
// .AddTransient<IMenuService, HardCodedMenuService>();

builder.Services
 .AddTransient<IMenuService, MenuService>();

//builder.Services
// .AddTransient<IOrderService, ConsoleOrderService>();

builder.Services
 .AddTransient<IOrderService, OrderService>();


await builder.Build().RunAsync();
