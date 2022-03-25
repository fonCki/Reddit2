using Application.Contracts;
using Entities.Model;
using JsonDataAccess.Context;

namespace JsonDataAccess; 

public class JsonUserDAO : IUserDAO{
    
    private JsonContext jsonContext;

    public JsonUserDAO(JsonContext jsonContext) {
        this.jsonContext = new JsonContext();
    }
    
    public async Task<ICollection<User>> GetUsersAsync() {
        return jsonContext.Forum.Users;
    }
    

    public async Task<User?> GetByUserAsyncByEmail(string email) {
        User? foundedUser = jsonContext.Forum.Users.
            FirstOrDefault(u => email.Equals(u.Email));
        return foundedUser;
    }

    public async Task<User> AddUserAsync(User user) {
        if (await existUser(user.Email)) {
            throw new Exception("User already exist");
        }
        else {
            jsonContext.Forum.Users.Add(user);
            jsonContext.SaveChangesAsync();
            return user;
        }
    }

    public async Task DeleteUserAsync(string email) {
        jsonContext.Forum.Users.Remove(GetByUserAsyncByEmail(email).Result);
        jsonContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user) {
        User userToUpdate = GetByUserAsyncByEmail(user.Email).Result;
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Password = user.Password;
        userToUpdate.Password = user.Password;
        jsonContext.SaveChangesAsync();
    }

    private async Task<bool> existUser(string email) {
        return jsonContext.Forum.Users.Any(u => email.Equals(u.Email));
    }
    
}
