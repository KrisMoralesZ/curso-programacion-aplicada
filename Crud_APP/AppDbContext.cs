using Crud_APP;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
  public DbSet<Person> People { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite("Data Source=people.db");
  }
}
