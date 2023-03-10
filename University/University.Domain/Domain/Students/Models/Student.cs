using University.Core.Domain.StudentGroups.Models;

namespace University.Core.Domain.Students.Models;

public class Student
{
    private Student()
    {

    }

    private Student(Guid id, string firstName, string lastName, string middleName, Guid groupId)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        GroupId = groupId;
    }

    public Guid Id { get; private set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public Guid GroupId { get; private set; }

    public StudentGroup Group { get; private set; }

    public static Student Create(string firstName, string lastName, string middleName, Guid groupId)
    {
        return new Student(Guid.NewGuid(), firstName, lastName, middleName, groupId);
    }
}