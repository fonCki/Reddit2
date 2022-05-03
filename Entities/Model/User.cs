using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class User {
    
    [JsonConstructor] public User() { }
     
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