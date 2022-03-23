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

    public Post(string header, string body, User writtenBy, string image) {
        UID = getUID();
        Image = image;
        Header = header;
        Body = body;
        WrittenBy = writtenBy;
        DateTime = System.DateTime.Now;
    }

    private string getUID() { // Change this please
        string tempUID = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + "&"; 
        for (int i = 0; i < 6; i++) {
            tempUID += new Random().Next(10);
        }

        return tempUID;
    }
}