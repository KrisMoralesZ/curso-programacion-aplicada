using Avalonia.Controls;

namespace TempCalculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        btnCtoF.Click += (s, e) => ConvertirCtoF();
        btnFtoC.Click += (s, e) => ConvertirFtoC();
    }

    private void ConvertirCtoF()
    {
        if (double.TryParse(txtValor.Text, out double c))
        {
            double f = (c * 9 / 5) + 32;
            lblResultado.Text = $"{c} °C = {f:F2} °F";
        }
        else
        {
            lblResultado.Text = "Valor inválido.";
        }
    }

    private void ConvertirFtoC()
    {
        if (double.TryParse(txtValor.Text, out double f))
        {
            double c = (f - 32) * 5 / 9;
            lblResultado.Text = $"{f} °F = {c:F2} °C";
        }
        else
        {
            lblResultado.Text = "Valor inválido.";
        }
    }
}
