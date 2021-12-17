using Microsoft.EntityFrameworkCore;
using PizzaPlace.Shared;

namespace PizzaPlace.Server
{
  public class PizzaPlaceDbContext : DbContext
  {
    public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options)
      : base(options) { }

    public DbSet<Pizza> Pizzas { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      var pizzaEntity = modelBuilder.Entity<Pizza>();

      pizzaEntity.HasKey(pizza => pizza.Id);
      pizzaEntity.Property(pizza => pizza.Name)
        .HasMaxLength(80);
      pizzaEntity.Property(pizza => pizza.Price)
        .HasColumnType("money");
      pizzaEntity.Property(pizza => pizza.Spiciness)
        .HasConversion<string>();
    }
  }
}
