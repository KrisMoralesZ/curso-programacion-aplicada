using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public class Producto
{
    [Key]
    public int IdProducto { get; set; }
    public string ProductoNombre { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
}