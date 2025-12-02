using Microsoft.EntityFrameworkCore;
using Reporte.Models;

namespace Reporte.Data;

public class AppDbContext : DbContext
{
  public DbSet<Person> Persons { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite("Data Source=Reporte.db");
  }
}