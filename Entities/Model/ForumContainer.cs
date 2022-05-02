using System.ComponentModel.DataAnnotations;

namespace Entities.Model; 

public class ForumContainer {
    
    // Add e.g. ICollection<Post> or ICollection<SubForum> or similar.
    
    [Key]
    public Guid Id { get; set; }
    public ICollection<User> Users { get; set; }
    
    public ICollection<Post> Posts { get; set; }

    public ForumContainer() {
        Users = new List<User>();
        Posts = new List<Post>();
    }
}