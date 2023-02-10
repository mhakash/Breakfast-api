namespace BuberBreakfast.Models;

public class Breakfast
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StarDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public List<string>? Savory { get; set; }
    public List<string>? Sweet { get; set; }

}