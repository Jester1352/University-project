namespace University.Core.Domain.Departments.Models;

public class Department
{
    private Department()
    {

    }

    private Department(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; set; }

    public static Department Create(string name)
    {
        return new Department(new Guid(), name);
    }
}