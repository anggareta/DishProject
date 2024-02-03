using Microsoft.EntityFrameworkCore;
using RestoProject.Shared.Entities;

namespace RestoProject.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<DishOrder>().HasData(
        new DishOrder { OrderId = "ABC01012024-001", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01012024-002", Name = "Icha", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01022024-002", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 2, 1) }
      );
    }

    public DbSet<DishOrder> TMDishOrders { get; set; }
  }
}
