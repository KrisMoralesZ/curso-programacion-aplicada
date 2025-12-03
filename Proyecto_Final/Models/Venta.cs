using System;

namespace Proyecto_Final.Models;

public class Venta
{
    public int IdVenta { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
}