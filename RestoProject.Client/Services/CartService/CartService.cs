using Blazored.LocalStorage;
using Blazored.Toast.Services;
using RestoProject.Client.Services.DishService;
using RestoProject.Shared.DTOs;
using RestoProject.Shared.Entities;
using System.Net.Http.Json;

namespace RestoProject.Client.Services.CartService
{
  public class CartService : ICartService
  {
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;
    private readonly IToastService _toastService;
    private readonly IDishService _dishService;

    public event Action OnChange;

    public CartService(
      HttpClient http,
      ILocalStorageService localStorage,
      IToastService toastService,
      IDishService dishService)
    {
      _http = http;
      _localStorage = localStorage;
      _toastService = toastService;
      _dishService = dishService;
    }

    public async Task AddToCart(CartItem item)
    {
      var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
      if (cart == null)
      {
        cart = new List<CartItem>();
      }

      var sameItem = cart
          .Find(x => x.DishId == item.DishId && x.FlavorId == item.FlavorId);
      if (sameItem == null)
      {
        cart.Add(item);
      }
      else
      {
        sameItem.Quantity += item.Quantity;
      }

      await _localStorage.SetItemAsync("cart", cart);

      var product = await _dishService.GetProduct(item.DishId);
      _toastService.ShowSuccess(product.Name, null);

      OnChange.Invoke();
    }
    public async Task<List<CartItem>> GetCartItems()
    {
      var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
      if (cart == null)
      {
        return new List<CartItem>();
      }
      return cart;
    }

    public async Task DeleteItem(CartItem item)
    {
      var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
      if (cart == null)
      {
        return;
      }

      var cartItem = cart.Find(x => x.DishId == item.DishId && x.FlavorId == item.FlavorId);
      cart.Remove(cartItem);

      await _localStorage.SetItemAsync("cart", cart);
      OnChange.Invoke();
    }

    public async Task EmptyCart()
    {
      await _localStorage.RemoveItemAsync("cart");
      OnChange.Invoke();
    }

    public async Task SubmitCart(DishOrder dishOrder)
    {
      var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
      dishOrder.CartItems = cart;
      var restult = await _http.PostAsJsonAsync("api/dishorders", dishOrder);
      await _localStorage.RemoveItemAsync("cart");
      OnChange.Invoke();
    }
  }
}