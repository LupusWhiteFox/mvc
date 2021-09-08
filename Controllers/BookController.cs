using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using aspnet.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace aspnet.Controllers
{
  [Route("api/book")]
  [ApiController]
  public class BookController : Controller
  {

    private readonly DBclass _db;
    public BookController(DBclass db)
    {
      _db = db;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      return Json(new { data = await _db.Books.ToListAsync() });
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      var bookFromDb = await _db.Books.FirstOrDefaultAsync(u => u.id == id);
      if (bookFromDb == null)
      {
        return Json(new { success = false, message = "Erorr" });
      }

      _db.Books.Remove(bookFromDb);
      await _db.SaveChangesAsync();
      return Json(new { success = true, message = "Delete Successful" });
    }


  }
}