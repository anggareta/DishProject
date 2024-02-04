using RestoProject.Shared.Entities;

namespace RestoProject.Client.Services.DishService
{
  public interface IDishService
  {
    event Action OnChange;
    List<Dish> Dish{ get; set; }
    Task LoadProducts(string categoryUrl = null);
    Task<Dish> GetProduct(int id);
    Task<List<Dish>> SearchProducts(string searchText);
  }
}
