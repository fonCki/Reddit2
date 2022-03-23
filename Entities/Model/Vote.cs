namespace Entities.Model; 

public class Vote {
    public short Value { get; set; }
    public User Voter { get; set; }

    public Vote(short value) {
        Value = value;
    }

    private void Validate(short value) {
        
    }
}