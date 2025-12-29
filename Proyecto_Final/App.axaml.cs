using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Proyecto_Final.Windows;

namespace Proyecto_Final;

public partial class App : Application
{
  public override void Initialize()
  {
    AvaloniaXamlLoader.Load(this);
  }

  public override void OnFrameworkInitializationCompleted()
  {
    AuthService.CreateInitialAdmin();

    if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
      // desktop.MainWindow = new MainWindow();
      desktop.MainWindow = new LoginWindow();
    }

    base.OnFrameworkInitializationCompleted();
  }
}