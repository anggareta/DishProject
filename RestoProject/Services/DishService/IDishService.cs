using RestoProject.Shared.Entities;

namespace RestoProject.Services.DishService
{
  public interface IDishService
  {
    Task<List<Dish>> GetAllProducts();
    Task<List<Dish>> GetProductsByCategory(string categoryUrl);
    Task<Dish> GetProduct(int id);
    Task<List<Dish>> SearchProducts(string searchText);
  }
}
