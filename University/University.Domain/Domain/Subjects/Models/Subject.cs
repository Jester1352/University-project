using University.Core.Domain.Teachers.Models;

namespace University.Core.Domain.Subjects.Models;

public class Subject
{
    private Subject()
    {
    }

    private Subject(Guid id, string name, int code)
    {
        Id = id;
        Name = name;
        Code = code;
    }

    public Guid Id { get; private set; }

    public string Name { get; set; }

    public int Code { get; set; }

    public static Subject Create(string name, int code)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentOutOfRangeException(nameof(name));
        return new Subject(Guid.NewGuid(), name, code);
    }

    public void Update(Subject subject)
    {
        Name = subject.Name;
        Code = subject.Code;
    }
}