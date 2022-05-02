using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Model; 

public class Vote {
    
    
    [Key]
    public Guid Id { get; set; }
    
    public short Value { get; set; }
    
    public User Voter { get; set; }

    public Vote() { }

    public Vote(short value) {
        Value = value;
    }

    private void Validate(short value) {
        
    }
}