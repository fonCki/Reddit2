namespace Entities.Model; 

public class SubForum {
    public User OwnedBy { get; }
    public string Title { get; set; }
    public string Description { get; set; }
    
    public ICollection<Post> Posts { get; set; }

    public SubForum(User ownedBy) {
        OwnedBy = ownedBy;
        Posts = new List<Post>();
    }

    public SubForum(User ownedBy, string title, string description) {
        OwnedBy = ownedBy;
        Title = title;
        Description = description;
        Posts = new List<Post>();
    }
}