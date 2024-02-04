using RestoProject.Shared.Entities;
using System.Net.Http.Json;

namespace RestoProject.Client.Services.DishService
{
  public class DishService(HttpClient http) : IDishService
  {
    private readonly HttpClient _http = http;

    public event Action OnChange;

    public List<Dish> Dish { get; set; } = new List<Dish>();

    public async Task LoadProducts(string categoryUrl = null)
    {
      if (categoryUrl == null)
      {
        Dish = await _http.GetFromJsonAsync<List<Dish>>("api/dish");
      }
      else
      {
        Dish = await _http.GetFromJsonAsync<List<Dish>>($"api/dish/category/{categoryUrl}");
      }
      OnChange.Invoke();
    }

    public async Task<Dish> GetProduct(int id)
    {
      return await _http.GetFromJsonAsync<Dish>($"api/dish/{id}");
    }

    public async Task<List<Dish>> SearchProducts(string searchText)
    {
      return await _http.GetFromJsonAsync<List<Dish>>($"api/dish/search/{searchText}");
    }
  }
}
