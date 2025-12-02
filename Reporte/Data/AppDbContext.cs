using Microsoft.EntityFrameworkCore;
using Mi_Reporte.Models;

namespace Mi_Reporte.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=mi_reporte.db");
    }
}