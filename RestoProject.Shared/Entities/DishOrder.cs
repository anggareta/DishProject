using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoProject.Shared.Entities
{
  public class DishOrder
  {
    [Key]
    [StringLength(20)]
    public required string OrderId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<CartItem> CartItems { get; set; }

    public DateTime OrderTime { get; set; }
  }
  
}
