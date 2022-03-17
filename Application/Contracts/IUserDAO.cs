using Entities.Model;

namespace Application.Contracts; 


public interface IUserDAO {

    public Task<ICollection<User>> GetUsersAsync();
    public Task<User> GetByUserName(string userName);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(string userName);
    public Task UpdateUserAsync(User user);
    
}