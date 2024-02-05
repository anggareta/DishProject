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
    public DbSet<Users> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Users>()
        .HasKey(k => new { k.Username });

      modelBuilder.Entity<DishVariant>()
        .HasKey(p => new { p.DishId, p.FlavorId });

      modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Foods", Url = "foods", Icon = "book" },
        new Category { Id = 2, Name = "Drinks", Url = "drinks", Icon = "camera-slr" },
        new Category { Id = 3, Name = "Desserts", Url = "desserts", Icon = "aperture" }
      );

      modelBuilder.Entity<Users>().HasData(
        new Users { Username = "admin", Password = "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", Name = "Admin", Role = 0 },
        new Users { Username = "meja_1", Password = "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", Name = "Meja 1", Role = 1 },
        new Users { Username = "meja_2", Password = "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", Name = "Meja 2", Role = 1 },
        new Users { Username = "meja_3", Password = "6a67e39f6ecf03658deb4f130682ae18269c3c31083b191213cbbb27f8ece75f", Name = "Meja 3", Role = 1 }
      );

      modelBuilder.Entity<Dish>().HasData(
        new Dish
        {
          Id = 1,
          CategoryId = 1,
          Name = "Nasi Goreng Kambing",
          Description = "Nasi goreng adalah makanan jalanan populer di Asia. Di beberapa negara Asia, restoran-restoran kecil, gerai-gerai pinggir jalan dan pedagang keliling mengkhususkan diri dalam menyajikan nasi goreng.",
          Image = "https://placehold.co/200x200/png?text=Nasi+Goreng+Kambing",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 2,
          CategoryId = 1,
          Name = "Sate Kambing",
          Description = "Sate kambing adalah sejenis makanan sate terbuat dari daging kambing. daging kambing tersebut disate (ditusuk dengan bambu yang dibentuk seperti lidi yang agak besar) dan dibumbui dengan rempah-rempah dan bumbu dapur, kemudian dibakar.",
          Image = "https://placehold.co/200x200/png?text=Sate+Kambing",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 3,
          CategoryId = 2,
          Name = "Jus",
          Description = "Jus atau sari adalah minuman yang terbuat dari ekstraksi atau pemerasan cairan alami yang terkandung dalam buah dan sayuran.",
          Image = "https://placehold.co/200x200/png?text=Jus",
          DateCreated = new DateTime(2024, 1, 1)
        },
        new Dish
        {
          Id = 4,
          CategoryId = 3,
          Name = "Es Krim",
          Description = "Es krim' merupakan sebuah makanan beku yang dibuat dari produk susu seperti krim, lalu dicampur dengan perasa dan pemanis buatan ataupun alami. terdapat beberapa vaian rasa",
          Image = "https://placehold.co/200x200/png?text=Ice+Cream",
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
        new Flavor { Id = 7, Name = "Stroberi" },
        new Flavor { Id = 8, Name = "Alpukat" },
        new Flavor { Id = 9, Name = "ala-carte" },
        new Flavor { Id = 10, Name = "tambah Nasi" },
        new Flavor { Id = 11, Name = "tambah Lontong" }
      );

      modelBuilder.Entity<DishVariant>().HasData(
        new DishVariant
        {
          DishId = 1,
          FlavorId = 1,
          Price = 18.00m,
          OriginalPrice = 18.00m
        },
        new DishVariant
        {
          DishId = 2,
          FlavorId = 1,
          Price = 30.00m,
          OriginalPrice = 30.00m
        },
        new DishVariant
        {
          DishId = 3,
          FlavorId = 7,
          Price = 12.00m,
          OriginalPrice = 12.00m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 5,
          Price = 11.00m,
          OriginalPrice = 10.00m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 6,
          Price = 11.50m,
          OriginalPrice = 10.00m
        },
        new DishVariant
        {
          DishId = 4,
          FlavorId = 7,
          Price = 12.00m,
          OriginalPrice = 10.00m
        },
        new DishVariant
        {
          DishId = 3,
          FlavorId = 8,
          Price = 13.00m,
          OriginalPrice = 10.00m
        },
        new DishVariant
        {
          DishId = 2,
          FlavorId = 10,
          Price = 35.00m,
          OriginalPrice = 30.00m
        },
        new DishVariant
        {
          DishId = 2,
          FlavorId = 11,
          Price = 37.00m,
          OriginalPrice = 30.00m
        }
      );

      modelBuilder.Entity<DishOrder>().HasData(
        new DishOrder { OrderId = "ABC01012024-001", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01012024-002", Name = "Icha", Description = "", OrderTime = new DateTime(2024, 1, 1) },
        new DishOrder { OrderId = "ABC01022024-002", Name = "Ayus", Description = "", OrderTime = new DateTime(2024, 2, 1) }
      );

    }

    public DbSet<CartItem> Orders { get; set; }
    public DbSet<DishOrder> DishOrders { get; set; }

  }
}
