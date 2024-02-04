using Microsoft.AspNetCore.Components.Forms;
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

    public DbSet<Category> TMCategory { get; set; }
    public DbSet<Dish> TMDish { get; set; }
    public DbSet<Flavor> TMFlavor { get; set; }
    public DbSet<DishVariant> TTDishVariant { get; set; }
    public DbSet<Stats> Stats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<DishVariant>()
        .HasKey(p => new { p.DishId, p.FlavorId });

      modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Foods", Url = "foods", Icon = "book" },
        new Category { Id = 2, Name = "Drinks", Url = "drinks", Icon = "camera-slr" },
        new Category { Id = 3, Name = "Desserts", Url = "desserts", Icon = "aperture" }
      );

      modelBuilder.Entity<Dish>().HasData(
        new Dish
        {
          Id = 1,
          CategoryId = 1,
          Name = "Nasi Goreng Kambing",
          Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.",
          Image = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 2,
          CategoryId = 1,
          Name = "Sate Kambing",
          Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.",
          Image = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 3,
          CategoryId = 2,
          Name = "Jus",
          Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.",
          Image = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 4,
          CategoryId = 3,
          Name = "Ice Cream",
          Description = "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.",
          Image = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
          DateCreated = new DateTime(2024, 1, 1)
        }
      );

      modelBuilder.Entity<Flavor>().HasData(
        new Flavor { Id = 1, Name = "Kaming" },
        new Flavor { Id = 2, Name = "Sapi" },
        new Flavor { Id = 3, Name = "Ayam" },
        new Flavor { Id = 4, Name = "Ikan" },
        new Flavor { Id = 5, Name = "Vanila" },
        new Flavor { Id = 6, Name = "Coklat" },
        new Flavor { Id = 7, Name = "Stroberi" }
      );

      modelBuilder.Entity<DishVariant>().HasData(
        new DishVariant
        {
          DishId = 1,
          FlavorId = 1,
          Price = 9.99m,
          OriginalPrice = 19.99m
        },
        new DishVariant
        {
          DishId = 2,
          FlavorId = 1,
          Price = 9.99m,
          OriginalPrice = 19.99m
        },
        new DishVariant
        {
          DishId = 3,
          FlavorId = 7,
          Price = 9.99m,
          OriginalPrice = 19.99m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 5,
          Price = 9.99m,
          OriginalPrice = 19.99m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 6,
          Price = 9.99m,
          OriginalPrice = 19.99m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 7,
          Price = 9.99m,
          OriginalPrice = 19.99m
        }
      );

      modelBuilder.Entity<DishOrder>().HasData(
        new DishOrder { OrderId = "ABC01012024-001", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01012024-002", Name = "Icha", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01022024-002", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 2, 1) }
      );

    }

    public DbSet<DishOrder> TMDishOrders { get; set; }
  }
}
