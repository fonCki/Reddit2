using Application.Contracts;
using Entities.Model;

namespace JsonDataAccess; 

public class JsonUserDAO : IUserDAO{
    
    //  private ICollection<User> users;
    private JsonContext jsonContext;

    public JsonUserDAO() {
        this.jsonContext = new JsonContext();
    }
    
    /*
    public JsonUserDAO(JsonContext jsonContext) {
        this.jsonContext = jsonContext;
        //     this.users = jsonContext.Forum.Users;
    }*/

    public async Task<ICollection<User>> GetUsersAsync() {
        return jsonContext.Forum.Users;
    }
    

    public async Task<User> GetByUserByEmail(string email) {
        return jsonContext.Forum.Users.First(user => user.Email == email);

    }

    public async Task<User> AddUserAsync(User user) {
        try {
            await GetByUserByEmail(user.Email);
            Console.WriteLine("hola");
            throw new Exception("user exist");
        }
        catch (Exception e) {
            jsonContext.Forum.Users.Add(user);
            await jsonContext.SaveChangesAsync();
            Console.WriteLine("Writed");
            return user;
        }
    }

    public async Task DeleteUserAsync(string email) {
        jsonContext.Forum.Users.Remove(GetByUserByEmail(email).Result);
        jsonContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user) {
        User userToUpdate = GetByUserByEmail(user.UserName).Result;
        userToUpdate.Password = user.Password;
        jsonContext.SaveChangesAsync();
    }

    
}
