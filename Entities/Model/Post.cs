namespace Entities.Model;

public class Post {
    public string Header { get; set; }
    public string Body { get; set; }

    public string Image { get; set; }

    public String UID { get; private set; }
    public ICollection<Vote> Votes { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public User WrittenBy { get; set; }
    public DateTime DateTime { get; }
    
    public Post(string uid, string header, string body, User writtenBy, string image, DateTime dateTime) {
        UID = uid;
        Image = image;
        Header = header;
        Body = body;
        WrittenBy = writtenBy;
        DateTime = dateTime;
    }
}