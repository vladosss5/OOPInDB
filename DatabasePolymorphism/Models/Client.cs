namespace DatabasePolymorphism.Models;

public class Client : Person
{
    public int CountVisits { get; set; }
    
    public string? FName { get; set; }
}