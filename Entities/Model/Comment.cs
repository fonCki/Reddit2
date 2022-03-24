namespace Entities.Model; 

public class Comment {
    public String Body { get; set; }
    public Comment ParentComment { get; set; }
    public ICollection<Vote> Votes { get; set; }
    public User WrittenBy { get; set; }

    public Comment(string body, User writtenBy) {
        Body = body;
        WrittenBy = writtenBy;
    }
}