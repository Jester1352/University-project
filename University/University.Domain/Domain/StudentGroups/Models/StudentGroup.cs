namespace University.Core.Domain.StudentGroups.Models;

public class StudentGroup
{
    private StudentGroup()
    {

    }

    private StudentGroup(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public static StudentGroup Create(string name)
    {
        return new StudentGroup(new Guid(), name);
    }
}