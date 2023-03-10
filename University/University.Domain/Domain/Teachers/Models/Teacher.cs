namespace University.Core.Domain.Teachers.Models;

public class Teacher
{
    private Teacher()
    {

    }

    private Teacher(Guid id, string firstName, string lastName, string middleName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public Guid Id { get; private set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public IReadOnlyCollection<TeacherSubject> Subjects { get; private set; }

    public static Teacher Create(string firstName, string lastName, string middleName)
    {
        return new Teacher(Guid.NewGuid(), firstName, lastName, middleName);
    }
}