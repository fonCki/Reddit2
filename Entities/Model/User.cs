using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Entities.Model;

public class User {
     public User() { }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public User(string fName, string lastName, string email, string password, string imgPath) {
        FirstName = fName;
        LastName = lastName;
        Email = email;
        Password = password;
        ImagePath = imgPath;
    }

    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    [Key]
    public string Email { get; set; }

    public string Password { get; set; }
    public string ImagePath { get; set; }
    
}