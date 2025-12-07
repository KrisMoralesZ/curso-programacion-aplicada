using Avalonia.Controls;
using Avalonia.Interactivity;
using Proyecto_Final.Models;
using Proyecto_Final.Services;

namespace Proyecto_Final.Views;

public partial class ClientesView : UserControl
{
    private readonly ClienteService _service = new();

    public ClientesView()
    {
        InitializeComponent();
        Cargar();
    }

    private void Cargar()
    {
        TablaClientes.ItemsSource = _service.GetAll();
    }

    private void Agregar_Click(object? sender, RoutedEventArgs e)
    {
        var c = new Cliente
        {
            Nombre = TxtNombre.Text!,
            Domicilio = TxtDomicilio.Text!,
            Telefono = TxtTelefono.Text!,
            Correo = TxtCorreo.Text!
        };

        _service.Add(c);
        Cargar();
    }

    private void Actualizar_Click(object? sender, RoutedEventArgs e)
    {
        if (TablaClientes.SelectedItem is Cliente cli)
        {
            cli.Nombre = TxtNombre.Text!;
            cli.Domicilio = TxtDomicilio.Text!;
            cli.Telefono = TxtTelefono.Text!;
            cli.Correo = TxtCorreo.Text!;
            _service.Update(cli);
            Cargar();
        }
    }

    private void Eliminar_Click(object? sender, RoutedEventArgs e)
    {
        if (TablaClientes.SelectedItem is Cliente cli)
        {
            _service.Delete(cli.IdCliente);
            Cargar();
        }
    }
}