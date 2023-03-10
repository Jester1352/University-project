using University.Core.Domain.Students.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Student.Common;

public class StudentsRepository : IStudentsRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public StudentsRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public University.Core.Domain.Students.Models.Student Find(Guid id)
    {
        var student = _universityDbContext.Students.SingleOrDefault(student => student.Id == id);
        return student ?? throw new InvalidOperationException();
    }

    public void Add(University.Core.Domain.Students.Models.Student student)
    {
        _universityDbContext.Students.Add(student);
    }

    public void Delete(Guid id)
    {
        var studentToBeRemoved = _universityDbContext.Students.SingleOrDefault(student => student.Id == id);
        if (studentToBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.Students.Remove(studentToBeRemoved);
    }
}