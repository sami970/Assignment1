using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models;

public class User
{
    
    [Required, MaxLength(64)] public string UserName { get;  set; }
    [Required, MaxLength(64)] public string Password { get;  set; }

    public User(String userName, String password)
    {
        this.UserName = userName;
        this.Password = password;
    }

}