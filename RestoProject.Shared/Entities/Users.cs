using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoProject.Shared.Entities
{
  public class Users
  {
    [MaxLength(10)]
    public string Username { get; set; }

    [MaxLength(80)]
    public string Password { get; set; }

    [MaxLength(30)]
    public string Name { get; set; }

    public int Role { get; set; }
  }
}
