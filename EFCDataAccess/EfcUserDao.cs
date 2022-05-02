using Application.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess; 

public class EfcUserDao : IUserDAO {

    private readonly ForumContextClass context;

    public EfcUserDao(ForumContextClass context) {
        this.context = context;
    }

    public async Task<ICollection<User>> GetUsersAsync() {
        ICollection<User> users = await context.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetByUserAsyncByEmail(string email) {
        User? user = await context.FindAsync<User>(email);
        return user;
    }

    public async Task<User> AddUserAsync(User user) {
        EntityEntry<User> added = await context.AddAsync(user);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task DeleteUserAsync(string email) {
        User? user = await context.Users.FindAsync(email);
        if (user == null) return;
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<User> UpdateUserAsync(User user) {
        User? findedUser = await context.Users.FindAsync(user.Email);
        findedUser.Password = user.Password;
        findedUser.FirstName = user.FirstName;
        findedUser.LastName = user.LastName;
        findedUser.ImagePath = user.ImagePath;
        await context.SaveChangesAsync();
        return findedUser;
    }
}