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

    public User(string fName, string lastName, string email, string password) {
        FirstName = fName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    [Required(ErrorMessage = "name is required")]
    [NotNull]
    // [MinLength(1, ErrorMessage = "name cannot be blank")]
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    
    
}