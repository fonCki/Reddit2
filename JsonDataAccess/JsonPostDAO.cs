using Application.Contracts;
using Entities.Model;
using JsonDataAccess.Context;

namespace JsonDataAccess;

public class JsonPostDAO : IPostDAO {
    private readonly JsonContext jsonContext;

    public JsonPostDAO(JsonContext jsonContext) {
        this.jsonContext = new JsonContext();
    }

    public async Task<ICollection<Post>> GetAllPostAsync() {
        return jsonContext.Forum.Posts;
    }

    public async Task<Post> AddPost(Post post) {
        jsonContext.Forum.Posts.Add(post);
        jsonContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post> GetPost(string UID) {
        return jsonContext.Forum.Posts.FirstOrDefault(p => UID.Equals(p.Uid))!;
    }

    public async Task<Post> AddComment(Comment comment) {
        var post = GetPost(comment.PostUid).Result;
        if (post != null) {
            post.Comments.Add(comment);
            await jsonContext.SaveChangesAsync();
        }

        return null;
    }
}