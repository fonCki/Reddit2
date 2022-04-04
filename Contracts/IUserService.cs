using Entities.Model;

namespace Contracts; 

public interface IUserService {
    public Task<ICollection<User>> GetUsersAsync();
    public Task<User> GetByUserAsyncByEmail(string email);
    public Task<User> AddUserAsync(User user);
    public Task DeleteUserAsync(string email);
    public Task<User> UpdateUserAsync(User user);
}