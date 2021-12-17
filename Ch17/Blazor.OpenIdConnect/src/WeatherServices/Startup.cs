using Blazor.Shared.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WeatherServices
{
  public class Startup
  {
    public Startup(IConfiguration configuration) => Configuration = configuration;// JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "WeatherServices",
          Version = "v1"
        });
      });
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
          builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
      });

      services.AddAuthorization(options =>
      {
        options.AddPolicy(Policies.FromBelgium,
          Policies.FromBelgiumPolicy());
      });


      services
        .AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", opt =>
        {
          opt.RequireHttpsMetadata = false; // for development perposes, disable in production!
          opt.Authority = "https://localhost:5011";
          opt.Audience = "u2uApi";
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(
          c =>
          c.SwaggerEndpoint("/swagger/v1/swagger.json",
                            "WeatherServices v1"));
      }
      app.UseHttpsRedirection();
      app.UseCors("CorsPolicy");
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
