using Entities.Model;

namespace Contracts; 

public interface IPostService {
    public Task<ICollection<Post>> GetAllPostAsync();
    public Task<Post> AddPost(Post post);
    public Task<Post> GetPost(string UID);
    public Task<Post> AddComment(String UID, Comment comment);
}