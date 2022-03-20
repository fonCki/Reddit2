using Application.Contracts;
using Entities.Model;

namespace JsonDataAccess; 

public class JsonUserDAO : IUserDAO{
    
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
    

    public async Task<User?> GetByUserAsyncByEmail(string email) {
        List<User> usersList = (List<User>) jsonContext.Forum.Users;
        User? foundedUser = usersList.Find(u => email.Equals(u.Email));
        return foundedUser;
    }

    public async Task<User> AddUserAsync(User user) {
        // User? foundedUser =  GetByUserByEmail(user.Email).Result;
        // Console.WriteLine(foundedUser.Email);
        if (await existUser(user.Email)) {
            throw new Exception("User already exist");
        }
        else { 
            jsonContext.Forum.Users.Add(user);
            jsonContext.SaveChangesAsync();
        }

        return null;
    }

    public async Task DeleteUserAsync(string email) {
        jsonContext.Forum.Users.Remove(GetByUserAsyncByEmail(email).Result);
        jsonContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user) {
        User userToUpdate = GetByUserAsyncByEmail(user.Email).Result;
        userToUpdate.Password = user.Password;
        jsonContext.SaveChangesAsync();
    }

    private async Task<bool> existUser(string email) {
        List<User> usersList = (List<User>) jsonContext.Forum.Users;
        return usersList.Exists(u => email.Equals(u.Email));
    }
    
}
