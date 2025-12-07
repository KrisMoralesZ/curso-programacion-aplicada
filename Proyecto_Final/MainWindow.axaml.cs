using Avalonia.Controls;
using Proyecto_Final.Views;

namespace Proyecto_Final;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void Clientes_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        VistaContenido.Content = new ClientesView();
    }
    
    private void Productos_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        VistaContenido.Content = new ProductosView();
    }
    
    private void Salir_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}