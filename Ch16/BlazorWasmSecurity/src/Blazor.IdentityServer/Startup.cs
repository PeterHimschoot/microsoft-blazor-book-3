using Blazor.IdentityServer.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Blazor.IdentityServer
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      // For testing only, don't use this in production
      services
        .AddIdentityServer()
        .AddInMemoryApiScopes(InMemoryConfig.GetApiScopes())
        .AddInMemoryApiResources(InMemoryConfig.GetApiResources())
        .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
        .AddTestUsers(InMemoryConfig.GetUsers())
        .AddInMemoryClients(InMemoryConfig.GetClients())
        .AddProfileService<CustomProfileService>()
        .AddDeveloperSigningCredential();

      services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseRouting();

      app.UseIdentityServer();

      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
      });
    }
  }
}
