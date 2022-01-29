using Blazor.Shared.OpenIdConnect;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy", builder => 
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
});

builder.Services
       .AddAuthentication("Bearer")
       .AddJwtBearer("Bearer", opt =>
       {
         opt.RequireHttpsMetadata = false; // for development purposes, disable in production!
         opt.Authority = "https://localhost:5011";
         opt.Audience = "u2uApi";
       });

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy(Policies.FromBelgium,  Policies.FromBelgiumPolicy());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
