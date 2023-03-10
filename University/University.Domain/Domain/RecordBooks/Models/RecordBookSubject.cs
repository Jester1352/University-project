using University.Core.Domain.Subjects.Models;

namespace University.Core.Domain.RecordBooks.Models;

public class RecordBookSubject
{
    public Guid RecordId { get; set; }

    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; }

    public int Grade { get; set; }
}