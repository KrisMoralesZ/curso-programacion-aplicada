using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

namespace Mi_Reporte.Services;

public class VentaService
{
    public List<Venta> GetAll()
    {
        using var db = new AppDbContext();
        return db.Ventas.ToList();
    }

    public List<Venta> GetByFecha(DateTime desde, DateTime hasta)
    {
        using var db = new AppDbContext();
        return db.Ventas
            .Where(v => v.Fecha >= desde && v.Fecha <= hasta)
            .ToList();
    }

    public void Add(Venta v)
    {
        using var db = new AppDbContext();
        db.Ventas.Add(v);
        db.SaveChanges();
    }
}