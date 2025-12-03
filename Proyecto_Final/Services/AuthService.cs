using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Proyecto_Final.Data;
using Proyecto_Final.Models;

public static class AuthService
{
    public static string Hash(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
    
    public static bool Validate(string username, string password)
    {
        using var db = new AppDbContext();
        var user = db.Users.FirstOrDefault(u => u.Username == username);
        if (user == null) return false;
        return user.PasswordHash == Hash(password);
    }
    
    public static void CreateInitialAdmin()
    {
        using var db = new AppDbContext();
        if (!db.Users.Any())
        {
            db.Users.Add(new User { Username = "admin", PasswordHash = Hash("admin123"), Role = "Admin" });
            db.SaveChanges();
        }
    }
}