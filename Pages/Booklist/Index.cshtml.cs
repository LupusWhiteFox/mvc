using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnet.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace aspnet.Pages.Booklist
{
  public class IndexModel : PageModel
  {
    private readonly DBclass _db;

    public IndexModel(DBclass db)
    {
      _db = db;
    }

    public IEnumerable<Book> Book { get; set; }


    public async Task OnGet()
    {
      Book = await _db.Books.ToListAsync();
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
      var book = await _db.Books.FindAsync(id);
      if (book == null)
      {
        return NotFound();
      }
      _db.Books.Remove(book);
      await _db.SaveChangesAsync();

      return RedirectToPage("Index");
    }

  }
}
