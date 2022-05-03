using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class Post {
    
    [Key]
    public String Uid { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public User WrittenBy { get; set; }
    public string Image { get; set; }
    public DateTime DateTime { get; set; }
    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    [JsonConstructor]
    public Post() { }
    
    public Post(string uid, string header, string body, User writtenBy, string image, DateTime dateTime, ICollection<Vote> votes, ICollection<Comment> comments) {
        Uid = uid?? "";
        Header = header?? "";
        Body = body?? "";
        WrittenBy = writtenBy;
        Image = image ?? "";
        DateTime = dateTime;
        Votes = votes;
        Comments = comments;
    }

    public Post(string header, string body, User writtenBy, string image) {
        Uid = Guid.NewGuid().ToString();
        Header = header?? "";
        Body = body?? "";
        WrittenBy = writtenBy;
        Image = image ?? "";
        DateTime = DateTime.Now;
        Votes = new List<Vote>();
        Comments = new List<Comment>();
    }

    public override string ToString() {
        return $"{nameof(Uid)}: {Uid}, {nameof(Header)}: {Header}, {nameof(Body)}: {Body}, {nameof(WrittenBy)}: {WrittenBy}, {nameof(Image)}: {Image}, {nameof(DateTime)}: {DateTime}, {nameof(Votes)}: {Votes}, {nameof(Comments)}: {Comments}";
    }
}