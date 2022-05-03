using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Model; 

public class Vote {
    
    
    [Key]
    public Guid Id { get; set; }
    
    public short Value { get; set; }
    
    public User Voter { get; set; }

    [JsonConstructor]
    public Vote() { }

    public Vote(short value) {
        Value = value;
    }

    private void Validate(short value) {
        
    }

    public override string ToString() {
        return $"{nameof(Id)}: {Id}, {nameof(Value)}: {Value}, {nameof(Voter)}: {Voter}";
    }
}