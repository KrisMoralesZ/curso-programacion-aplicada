using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Mi_Reporte.Services;
using Proyecto_Final.Models;

namespace Proyecto_Final.Views;

public partial class VentasView : UserControl
{
    private readonly VentaService _service = new();

    public VentasView()
    {
        InitializeComponent();
        Cargar();
    }

    private void Cargar()
    {
        TablaVentas.ItemsSource = _service.GetAll();
    }

    private void Registrar_Click(object? sender, RoutedEventArgs e)
    {
        _service.Add(new Venta
        {
            Fecha = DateTime.Now,
            Total = (decimal)NumTotal.Value
        });

        Cargar();
    }
}