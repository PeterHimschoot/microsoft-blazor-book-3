using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityProvider
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddIdentityServer()
              .AddInMemoryApiScopes(Config.GetApiScopes())
              .AddInMemoryApiResources(Config.GetApiResources())
              .AddInMemoryIdentityResources(Config.GetIdentityResources())
              .AddTestUsers(Config.GetUsers())
              .AddInMemoryClients(Config.GetClients())
              .AddDeveloperSigningCredential();
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
