using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public class Venta
{
    [Key]
    public int IdVenta { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
}