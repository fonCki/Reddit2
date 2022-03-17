namespace Entities.Model; 

public class ForumContainer {
    
    // Add e.g. ICollection<Post> or ICollection<SubForum> or similar.
    public ICollection<User> Users { get; set; }

    public ForumContainer() {
        Users = new List<User>();
    }
}