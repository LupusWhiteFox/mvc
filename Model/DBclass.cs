using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Model
{
  public class DBclass : DbContext
  {

    public DBclass(DbContextOptions<DBclass> optionsBuilder) : base(optionsBuilder)
    {

    }

    public DbSet<Book> Books { get; set; }



  }
}