using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Pages.Booklist
{
  public class UpsertModel : PageModel
  {
    private DBclass _db;


    public UpsertModel(DBclass db)
    {
      _db = db;
    }

    [BindProperty]
    public Book Books { get; set; }

    public async Task<IActionResult> OnGet(int? id)
    {
      Books = new Book();
      if (id == null)
      {
        return Page();
      }
      Books = await _db.Books.FirstOrDefaultAsync(u => u.id == id);
      if (Books == null)
      {
        return NotFound();
      }

      return Page();

    }

    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        if (Books.id == 0)
        {
          _db.Books.Add(Books);
        }

        else
        {
          _db.Books.Update(Books);
        }

        await _db.SaveChangesAsync();

        return RedirectToPage("Index");
      }
      return Page();
    }
  }
}