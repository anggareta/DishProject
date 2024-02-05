using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoProject.Shared.DTOs
{
  public class ResObj
  {
    public int statusId { get; set; }
    public string? message { get; set; }
    public string? error { get; set; } = null;
    
  }
}
