using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models;

public class User
{
    [Key]
    public int IdUser { get; set; }
    public string Username { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "User";
}