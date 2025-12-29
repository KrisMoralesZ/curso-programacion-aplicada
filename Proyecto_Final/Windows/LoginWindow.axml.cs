using Avalonia.Controls;
using MsBox.Avalonia;

namespace Proyecto_Final.Windows
{
  public partial class LoginWindow : Window
  {
    public LoginWindow()
    {
      InitializeComponent();
      AuthService.CreateInitialAdmin();
    }

    private async void Login_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
      var username = UserBox.Text;
      var password = PasswordBox.Text;

      if (AuthService.Validate(username, password))
      {
        await MessageBoxManager
            .GetMessageBoxStandard(
                title: "Login correcto",
                text: $"Bienvenido {username}")
            .ShowAsync();

        var mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
      }
      else
      {
        await MessageBoxManager
            .GetMessageBoxStandard(
                title: "Error",
                text: "Usuario o contraseña incorrectos"
                )
            .ShowAsync();
      }
    }
  }
}