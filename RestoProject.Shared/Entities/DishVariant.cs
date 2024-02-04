using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestoProject.Shared.Entities
{
  public class DishVariant
  {
    [JsonIgnore]
    public Dish Dish { get; set; }
    public int DishId { get; set; }
    public Flavor Flavor { get; set; }
    public int FlavorId { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal OriginalPrice { get; set; }
  }
}
