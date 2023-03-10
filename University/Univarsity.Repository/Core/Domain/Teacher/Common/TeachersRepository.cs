using University.Core.Domain.Teachers.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Teacher.Common;

public class TeachersRepository : ITeachersRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public TeachersRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public University.Core.Domain.Teachers.Models.Teacher Find(Guid id)
    {
        var teacher = _universityDbContext.Teachers.SingleOrDefault(teacher => teacher.Id == id);
        return teacher ?? throw new InvalidOperationException();
    }

    public void Add(University.Core.Domain.Teachers.Models.Teacher teacher)
    {
        _universityDbContext.Teachers.Add(teacher);
    }

    public void Delete(Guid id)
    {
        var teacherToBeRemoved = _universityDbContext.Teachers.SingleOrDefault(teacher => teacher.Id == id);
        if (teacherToBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.Teachers.Remove(teacherToBeRemoved);
    }
}