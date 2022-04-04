using Application.Contracts;
using Contracts;
using Entities.Model;

namespace Application; 

public class UserServiceImp : IUserService {
    
    private IUserDAO usertDao;

    public UserServiceImp(IUserDAO usertDao) {
        this.usertDao = usertDao;
    }

    public Task<ICollection<User>> GetUsersAsync() {
        return usertDao.GetUsersAsync();
    }

    public Task<User> GetByUserAsyncByEmail(string email) {
        return usertDao.GetByUserAsyncByEmail(email);
    }

    public Task<User> AddUserAsync(User user) {
        return usertDao.AddUserAsync(user);
    }

    public Task DeleteUserAsync(string email) {
        return usertDao.DeleteUserAsync(email);
    }

    public Task UpdateUserAsync(User user) {
        return usertDao.UpdateUserAsync(user);
    }
}