using Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCDataAccess; 

public class ForumContextClass : DbContext {
    public DbSet<Post> Posts { get; set; } = null;
    public DbSet<User> Users { get; set; } = null;
    public DbSet<Comment> Comments { get; set; } = null;
    public DbSet<ForumContainer> Forum { get; set; } = null;
    // public DbSet<SubForum> SubForums { get; set; } = null;
    public DbSet<Vote> Votes { get; set; } = null;
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = /Users/alfonsoridao/Projects/RiderProjects/Reddit2/EFCDataAccess/Forum.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(todo => todo.Uid);
        modelBuilder.Entity<User>().HasKey(todo => todo.Email);
    }

}