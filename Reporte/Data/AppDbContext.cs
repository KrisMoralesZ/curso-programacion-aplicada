using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Reporte.Models;

namespace Reporte.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      var dbPath = Path.Combine(AppContext.BaseDirectory, "Reporte.db");
      options.UseSqlite($"Data Source={dbPath}");
    }

  }
}
