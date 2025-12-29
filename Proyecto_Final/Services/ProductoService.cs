using System.Collections.Generic;
using System.Linq;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

namespace Mi_Reporte.Services;

public class ProductoService
{
    public List<Producto> GetAll()
    {
        using var db = new AppDbContext();
        return db.Productos.ToList();
    }

    public void Add(Producto p)
    {
        using var db = new AppDbContext();
        db.Productos.Add(p);
        db.SaveChanges();
    }

    public void Update(Producto p)
    {
        using var db = new AppDbContext();
        db.Productos.Update(p);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppDbContext();
        var prod = db.Productos.Find(id);
        if (prod != null)
        {
            db.Productos.Remove(prod);
            db.SaveChanges();
        }
    }
}