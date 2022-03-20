using Entities.Model;

namespace Application.Contracts; 


public interface IUserDAO {

    public Task<ICollection<User>> GetUsersAsync();
    public Task<User> GetByUserAsyncByEmail(string email);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(string email);
    public Task UpdateUserAsync(User user);
    
}