using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace aspnet.Model
{
  public class Book
  {
    [Key]
    public int id { get; set; }

    [Required]

    public string Name { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }

  }
}