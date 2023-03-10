using University.Core.Domain.Students.Models;

namespace University.Core.Domain.RecordBooks.Models;

public class RecordBook
{
    private RecordBook()
    {

    }

    private RecordBook(Guid id, Guid studentId)
    {
        Id = id;
        StudentId = studentId;
    }

    public Guid Id { get; private set; }

    public Guid StudentId { get; private set; }

    public Student Student { get; private set; }

    public IReadOnlyCollection<RecordBookSubject> Subjects { get; private set; }

    public static RecordBook Create(Guid studentId)
    {
        return new RecordBook(new Guid(), studentId);
    }
}