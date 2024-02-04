﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoProject.Shared.Entities
{
  public class Dish
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; } = "https://via.placeholder.com/300x300";
    public bool IsPublic { get; set; }
    public bool IsDeleted { get; set; }
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public List<DishVariant> Variants { get; set; } = new List<DishVariant>();
    public DateTime? DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateUpdated { get; set; }
    public int Views { get; set; }
  }
}
