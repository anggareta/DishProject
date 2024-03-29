﻿using RestoProject.Shared.Entities;

namespace RestoProject.Client.Services.CartService
{
  public interface ICartService
  {
    event Action OnChange;
    Task AddToCart(CartItem item);
    Task<List<CartItem>> GetCartItems();
    Task DeleteItem(CartItem item);
    Task SubmitCart(DishOrder dishOrder);
    Task EmptyCart();
  }
}
