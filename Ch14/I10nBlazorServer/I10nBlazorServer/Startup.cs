using I10nBlazorServer.Data;
using I10nBlazorServer.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace I10nBlazorServer
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => Configuration = configuration;

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    private RequestLocalizationOptions GetLocalizationOptions()
    {
      // This site gets the list of supported languages
      // from configuration. Open appsettings.json to add more...

      Dictionary<string, string> cultures =
        Configuration.GetCulturesSection();
      string[] supportedCultures =
        cultures.Keys.ToArray();
      RequestLocalizationOptions localizationOptions =
        new RequestLocalizationOptions()
        .SetDefaultCulture(supportedCultures[0])
        .AddSupportedCultures(supportedCultures)
        .AddSupportedUICultures(supportedCultures);

      localizationOptions.RequestCultureProviders.Clear();
      localizationOptions.RequestCultureProviders
        .Add(new CookieRequestCultureProvider());
      localizationOptions.RequestCultureProviders
        .Add(new AcceptLanguageHeaderRequestCultureProvider());

      return localizationOptions;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddRazorPages();
      services.AddServerSideBlazor();
      services.AddSingleton<WeatherForecastService>();
      services.AddLocalization();
      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseHttpLogging();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();


      // This middleware uses a couple of approuches to determine
      // the language used. More in documentation.
      app.UseRequestLocalization(GetLocalizationOptions());

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapBlazorHub();
        endpoints.MapFallbackToPage("/_Host");
      });
    }
  }
}
