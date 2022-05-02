using Application.Contracts;
using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess; 

public class EfcPostDao : IPostDAO  {
    
    private readonly ForumContextClass context;

    public EfcPostDao(ForumContextClass context) {
        this.context = context;
    }
    public async Task<ICollection<Post>> GetAllPostAsync() {
        ICollection<Post> posts = await context.Posts
            .Include(post => post.WrittenBy)
            .ToListAsync();
        return posts;
    }

    public async Task<Post> AddPost(Post post) {
        User? writtenBy = context.Users.Find(post.WrittenBy.Email);

        if (writtenBy != null) {
            post.WrittenBy = writtenBy;
        }

        EntityEntry<Post> added = await context.AddAsync(post);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<Post> GetPost(string UID) {
        Post? post = await context.Posts
            .Include(p => p.WrittenBy)
            .FirstAsync(p => p.Uid.Equals(UID));
        return post;
    }

    public async Task<Post> AddComment(string UID, Comment comment) {
        Post? post = await context.FindAsync<Post>(UID);
        post.Comments.Add(comment);
        try {
            await context.SaveChangesAsync();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }

        return await GetPost(UID);
    }
}