using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Model;

public class Comment {
    [Key] public Guid CID { get; set; }
    public string Body { get; set; }

    // public Comment? ParentComment { get; set; }
    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    public User WrittenBy { get; set; }
    
    public string PostUid { get; set; }

    [JsonConstructor]
    public Comment() { }

    public Comment(string body, User writtenBy, string postUid) {
        CID = Guid.NewGuid();
        Body = body;
        WrittenBy = writtenBy;
        PostUid = postUid;
        Votes = new List<Vote>();
    }

    public override string ToString() {
        return
            $"{nameof(CID)}: {CID}, {nameof(Body)}: {Body}, {nameof(Votes)}: {Votes}, {nameof(WrittenBy)}: {WrittenBy}";
    }
}