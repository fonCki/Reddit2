using Entities.Model;

namespace Application.Contracts; 

public interface IPostDAO {
    
   public Task<ICollection<Post>> GetAllPostAsync();
   public Task<Post> AddPost(Post post);
   public Task<Post> GetPost(string UID);
   public Task<Post> AddComment(Comment comment);
}