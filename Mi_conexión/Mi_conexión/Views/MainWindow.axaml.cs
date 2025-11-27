using Avalonia.Controls;
using Microsoft.Data.Sqlite;
using System;
using System.IO;

namespace Mi_conexión.Views;

public partial class MainWindow : Window
{
    private string connectionString = 
        $"Data Source={Path.Combine(AppContext.BaseDirectory, "Data", "mi_base.db")}";


    public MainWindow()
    {
        InitializeComponent();
        
        var dbPath = Path.Combine(AppContext.BaseDirectory, "Data", "mi_base.db");

        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        connectionString = $"Data Source={dbPath}";

        btnConectar.Click += (s, e) => ProbarConexion();
    }

    private void ProbarConexion()
    {
        try
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            
            string createTable = @"
                    CREATE TABLE IF NOT EXISTS Alumno(
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nombre TEXT NOT NULL,
                        edad INTEGER NOT NULL
                    )";

            var cmd = new SqliteCommand(createTable, connection);
            cmd.ExecuteNonQuery();

            txtResultado.Text = "Conexión exitosa";
        }
        catch (Exception ex)
        {
            txtResultado.Text = "Error en la conexión";
        }
    }
}