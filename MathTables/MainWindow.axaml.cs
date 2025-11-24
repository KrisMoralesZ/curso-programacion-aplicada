using System.Xml;
using Avalonia.Controls;

namespace MathTables;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        multiButton.Click += (s, e) => Multiplicar();
    }

    private void Multiplicar()
    {
        if (!int.TryParse(inputBox.Text, out int valor))
        {
            output.Text = "Ingresa un Numero";
            return;
        }

        string resultados = "";
        
        for (int i = 1; i < 11; i++)
        {
            resultados += $"{valor} X {i} = {valor * i}\n";
        }

        output.Text = resultados;
    }
}