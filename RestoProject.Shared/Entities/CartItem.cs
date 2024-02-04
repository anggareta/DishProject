using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoProject.Shared.Entities
{
  public class CartItem
  {
    public int DishId { get; set; }
    public int FlavorId { get; set; }
    public string DishName { get; set; }
    public string FlavorName { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public int Quantity { get; set; }
  }
}
