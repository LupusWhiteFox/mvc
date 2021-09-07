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
  public class CreateModel : PageModel
  {

    private readonly DBclass _db;

    public CreateModel(DBclass db)
    {
      _db = db;
    }
    [BindProperty]
    public Book Books { get; set; }

    public void OnGet()
    {

    }

    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        await _db.Books.AddAsync(Books);
        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
      }
      else
      {
        Console.WriteLine(Books);
        return Page();
      }
    }

  }
}
