using University.Core.Domain.Subjects.Models;

namespace University.Core.Domain.Teachers.Models;

public class TeacherSubject
{
    private TeacherSubject()
    {

    }

    public Guid TeacherId { get; set; }

    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; }
}