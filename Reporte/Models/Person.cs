namespace Reporte.Models;

public class Person
{
  public int Id { get; set; }
  public string Nombre { get; set; }
  public string Apellido { get; set; }

  public override string ToString() => $"{Nombre} {Apellido}";
}