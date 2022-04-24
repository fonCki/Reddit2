using System.Net.Http.Json;
using Application.Contracts;
using Contracts;
using Entities.Model;

namespace Application; 

public class PostServiceImp : IPostService {
    
    private IPostDAO postDao;

    public PostServiceImp(IPostDAO postDao) {
        this.postDao = postDao;
    }

    public Task<ICollection<Post>> GetAllPostAsync() {
        return postDao.GetAllPostAsync();
        
    }

    public Task<Post> AddPost(Post post) {
        return postDao.AddPost(post);
    }

    public Task<Post> GetPost(string UID) {
        return postDao.GetPost(UID);
    }

    public Task<Post> AddComment(string UID, Comment comment) {
        return postDao.AddComment(UID, comment);
    }
}