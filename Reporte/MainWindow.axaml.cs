using System.IO;
using System.Linq;
using Avalonia.Controls;
using Reporte.Data;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System.Diagnostics;
using System.Runtime.InteropServices;




namespace Reporte;

public partial class MainWindow : Window
{
    private AppDbContext _db = new();
    public MainWindow()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
            return;
        CargarDatos();
    }
    private void CargarDatos()
    {
        ListaPersonas.ItemsSource = _db.Persons.ToList();
    }

    private async void GenerarReporte_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var datos = _db.Persons.ToList();

        string reporte = "REPORTE DE PERSONAS\n\n";
        foreach (var p in datos)
            reporte += $"{p.Id} - {p.Nombre} {p.Apellido}\n";

        string ruta = "reporte.txt";
        await File.WriteAllTextAsync(ruta, reporte);

        await MessageBoxManager
            .GetMessageBoxStandard(
                title: "Reporte generado",
                text: $"El archivo {ruta} ha sido creado."
            )
            .ShowAsync();
        AbrirArchivo(ruta);
    }
    
    private void AbrirArchivo(string ruta)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = ruta,
                UseShellExecute = true
            });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", ruta);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", ruta);
        }
    }
}