using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aspnet.Pages.Booklist
{
  public class EditModel : PageModel
  {
    private DBclass _db;


    public EditModel(DBclass db)
    {
      _db = db;
    }

    [BindProperty]
    public Book Books { get; set; }

    public async Task OnGet(int id)
    {
      Books = await _db.Books.FindAsync(id);
    }
  }
}
