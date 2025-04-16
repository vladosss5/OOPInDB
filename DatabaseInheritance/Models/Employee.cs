namespace DatabaseInheritance.Models;

public class Employee : Person
{
    public string Login { get; set; }
    public string Password { get; set; }
}