namespace Entities.Model;

public class Post {
    public String UID { get; private set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public User WrittenBy { get; set; }
    public string Image { get; set; }
    public DateTime DateTime { get; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    
    public Post(string uid, string header, string body, User writtenBy, string image, DateTime dateTime, ICollection<Vote> votes, ICollection<Comment> comments) {
        UID = uid?? "";
        Header = header?? "";
        Body = body?? "";
        WrittenBy = writtenBy;
        Image = image ?? "";
        DateTime = dateTime;
        Votes = votes;
        Comments = comments;
    }
}