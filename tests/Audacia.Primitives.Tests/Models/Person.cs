namespace Audacia.Primitives.Tests.Models;

public class Person : IHasId
{
    public int Id { get; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    
    public Person(int id)
    {
        Id = id;
    }

    public Person(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
