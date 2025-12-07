using Avalonia.Controls;
using Avalonia.Interactivity;
using Mi_Reporte.Services;
using Proyecto_Final.Models;
using Proyecto_Final.Services;

namespace Proyecto_Final.Views;

public partial class ProductosView : UserControl
{
    private readonly ProductoService _service = new();

    public ProductosView()
    {
        InitializeComponent();
        Cargar();
    }

    private void Cargar()
    {
        TablaProductos.ItemsSource = _service.GetAll();
    }

    private void Agregar_Click(object? sender, RoutedEventArgs e)
    {
        _service.Add(new Producto
        {
            ProductoNombre = TxtProducto.Text!,
            Descripcion = TxtDescripcion.Text!,
            Cantidad = (int)NumCantidad.Value,
            Precio = (decimal)NumPrecio.Value
        });

        Cargar();
    }

    private void Actualizar_Click(object? sender, RoutedEventArgs e)
    {
        if (TablaProductos.SelectedItem is Producto p)
        {
            p.ProductoNombre = TxtProducto.Text!;
            p.Descripcion = TxtDescripcion.Text!;
            p.Cantidad = (int)NumCantidad.Value;
            p.Precio = (decimal)NumPrecio.Value;

            _service.Update(p);
            Cargar();
        }
    }

    private void Eliminar_Click(object? sender, RoutedEventArgs e)
    {
        if (TablaProductos.SelectedItem is Producto p)
        {
            _service.Delete(p.IdProducto);
            Cargar();
        }
    }
}