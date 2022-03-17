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

    public async Task<User> GetByUserName(string userName) {
        return jsonContext.Forum.Users.First(user => user.UserName == userName);
        
    }

    public async Task<User> AddUserAsync(User user) {
        // if (GetByUserName(user.UserName).Equals(null)) {
            jsonContext.Forum.Users.Add(user);
            await jsonContext.SaveChangesAsync();
            Console.WriteLine("Writed");
            return user;
      //  }
      //  return null;
    }

    public async Task DeleteUserAsync(string userName) {
        jsonContext.Forum.Users.Remove(GetByUserName(userName).Result);
        jsonContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user) {
        User userToUpdate = GetByUserName(user.UserName).Result;
        userToUpdate.Password = user.Password;
        jsonContext.SaveChangesAsync();
    }

}
