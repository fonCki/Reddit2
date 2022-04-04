using Application.Contracts;
using Entities.Model;
using JsonDataAccess.Context;

namespace JsonDataAccess;

public class JsonUserDAO : IUserDAO {
    private readonly JsonContext jsonContext;

    public JsonUserDAO(JsonContext jsonContext) {
        this.jsonContext = new JsonContext();
    }

    public async Task<ICollection<User>> GetUsersAsync() {
        return jsonContext.Forum.Users;
    }


    public async Task<User?> GetByUserAsyncByEmail(string email) {
        var foundedUser = jsonContext.Forum.Users.FirstOrDefault(u => email.Equals(u.Email));
        return foundedUser;
    }

    public async Task<User> AddUserAsync(User user) {
        if (await existUser(user.Email)) {
            throw new Exception("User already exist");
        }

        jsonContext.Forum.Users.Add(user);
        jsonContext.SaveChangesAsync();
        return user;
    }

    public async Task DeleteUserAsync(string email) {
        jsonContext.Forum.Users.Remove(GetByUserAsyncByEmail(email).Result);
        jsonContext.SaveChangesAsync();
    }

    public async Task<User> UpdateUserAsync(User user) {
        var userToUpdate = GetByUserAsyncByEmail(user.Email).Result;
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.ImagePath = user.ImagePath;
        userToUpdate.Password = user.Password;
        userToUpdate.Password = user.Password;
        await jsonContext.SaveChangesAsync();
        return userToUpdate;
    }

    private async Task<bool> existUser(string email) {
        return jsonContext.Forum.Users.Any(u => email.Equals(u.Email));
    }
}