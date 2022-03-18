namespace Entities.Model;

public class User {
    public User() { }

    public User(string userName, string password)
    {
        UserName = userName;
        Password = password;
    }

    public string UserName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    
    
}