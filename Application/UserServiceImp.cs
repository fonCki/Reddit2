using Application.Contracts;
using Contracts;
using Entities.Model;

namespace Application; 

public class UserServiceImp : IUserService {
    
    private IUserDAO userDao;

    public UserServiceImp(IUserDAO usertDao) {
        this.userDao = usertDao;
    }

    public Task<ICollection<User>> GetUsersAsync() {
        return userDao.GetUsersAsync();
    }

    public Task<User> GetByUserAsyncByEmail(string email) {
        return userDao.GetByUserAsyncByEmail(email);
    }

    public Task<User> AddUserAsync(User user) {
        return userDao.AddUserAsync(user);
    }

    public Task DeleteUserAsync(string email) {
        return userDao.DeleteUserAsync(email);
    }

    public Task<User> UpdateUserAsync(User user) {
        return userDao.UpdateUserAsync(user);
    }
}