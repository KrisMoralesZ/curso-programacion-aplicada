using System;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Mi_Reporte.Services;
using MsBox.Avalonia;

namespace Proyecto_Final.Views;

public partial class ReportesView : UserControl
{
  private readonly VentaService _service = new();

  public ReportesView()
  {
    InitializeComponent();
  }

  private async void GenerarReporte_Click(object? sender, RoutedEventArgs e)
  {
    var desde = FechaInicio.SelectedDate?.Date ?? DateTime.MinValue;
    var hasta = FechaFin.SelectedDate?.Date ?? DateTime.MaxValue;

    var ventas = _service.GetByFecha(desde, hasta);

    string path = "ReporteVentas.txt";

    var lines = ventas.Select(v => $"{v.IdVenta}\t{v.Fecha:yyyy-MM-dd}\t{v.Total:C}");

    File.WriteAllLines(path, lines);

    await MessageBoxManager
        .GetMessageBoxStandard(
            title: "Reporte generado",
            text: $"Archivo creado: {path}"
        )
        .ShowAsync();
    AbrirArchivo(path);
  }

  private void AbrirArchivo(string path)
  {
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
      Process.Start(new ProcessStartInfo
      {
        FileName = path,
        UseShellExecute = true
      });
    }
    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
    {
      Process.Start("xdg-open", path);
    }
    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
    {
      Process.Start("open", path);
    }
  }
}