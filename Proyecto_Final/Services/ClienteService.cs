using System.Collections.Generic;
using System.Linq;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

namespace  Proyecto_Final.Services;

public class ClienteService
{
    public List<Cliente> GetAll()
    {
        using var db = new AppDbContext();
        return db.Clientes.ToList();
    }

    public Cliente? GetById(int id)
    {
        using var db = new AppDbContext();
        return db.Clientes.Find(id);
    }

    public void Add(Cliente c)
    {
        using var db = new AppDbContext();
        db.Clientes.Add(c);
        db.SaveChanges();
    }

    public void Update(Cliente c)
    {
        using var db = new AppDbContext();
        db.Clientes.Update(c);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppDbContext();
        var cliente = db.Clientes.Find(id);
        if (cliente != null)
        {
            db.Clientes.Remove(cliente);
            db.SaveChanges();
        }
    }
}