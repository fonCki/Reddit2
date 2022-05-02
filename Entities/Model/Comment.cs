using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model; 

public class Comment {
    
    [Key]
    public string CID { get; set; }
    public string Body { get; set; }
    
    public Comment ParentComment { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public User WrittenBy { get; set; }

    public Comment() { }
    
    public Comment(string body, User writtenBy) {
        Body = body;
        WrittenBy = writtenBy;
    }
}