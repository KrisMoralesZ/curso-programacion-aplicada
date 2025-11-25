using System.Collections.Generic;
using Avalonia.Controls;

namespace TortasApp;



public partial class MainWindow : Window
{
    private readonly Dictionary<string, double> precios = new()
    {
        { "Paquete kids", 55 },
        { "Jalapeño", 25 },
        { "Italiana", 30 },
        { "Jamón", 25 },

        { "Chico", 12 },
        { "Mediano", 15 },
        { "Grande", 18 },

        { "Galletas", 13 },
        { "Pay de queso", 22 },
        { "Nieve", 15 },
        
        { "Ninguno", 0},
    };
    public MainWindow()
    {
        InitializeComponent();
        calcularButton.Click += (s, e) => Calcular_pago();
        tortaListBox.SelectionChanged += (s, e) => Verificar_obsequio();
    }

    private void Verificar_obsequio()
    {
        if(tortaListBox.SelectedItem is ListBoxItem item)
        {
            string seleccion = item.Content!.ToString()!;
            obsequioGrid.IsEnabled = seleccion == "Paquete kids";
        }
    }

    private void Calcular_pago()
    {
        double subtotal = 0;

        if (tortaListBox.SelectedItem is ListBoxItem tortaItem)
        {
            subtotal += precios[tortaItem.Content!.ToString()!];
        }

        if (refrescoListBox.SelectedItem is ListBoxItem refrescoItem)
        {
            subtotal += precios[refrescoItem.Content!.ToString()!];
        }

        if (postreListBox.SelectedItem is ListBoxItem postreItem)
        {
            subtotal += precios[postreItem.Content!.ToString()!];
        }

        double iva = subtotal * 0.16;
        
        double total = subtotal + iva;
        
        subtotalTextBox.Text = subtotal.ToString("0.00");
        ivaTextBox.Text = iva.ToString("0.00");
        totalTextBox.Text = total.ToString("0.00");
    }
}