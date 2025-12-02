using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Reporte.Data;
using Reporte.Models;

namespace Reporte;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        SeedDatabase();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private void SeedDatabase()
    {
        using var db = new AppDbContext();

        if (!db.Persons.Any())
        {
            db.Persons.AddRange(
                new Person { Nombre = "Juan", Apellido = "García" },
                new Person { Nombre = "Ana", Apellido = "Morales" }
            );

            db.SaveChanges();
        }
    }
}