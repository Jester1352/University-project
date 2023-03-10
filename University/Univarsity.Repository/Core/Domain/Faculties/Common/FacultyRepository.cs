using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Common;

public class FacultyRepository : IFacultyRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public FacultyRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public Faculty Find(Guid id)
    {
        var faculty = _universityDbContext.Faculties.SingleOrDefault(x => x.Id == id);
        return faculty ?? throw new InvalidOperationException();
    }

    public void Add(Faculty faculty)
    {
        _universityDbContext.Add(faculty);
    }

    public void Delete(Guid id)
    {
        var facultyBeRemoved = _universityDbContext.Faculties.SingleOrDefault(x => x.Id == id);
        if (facultyBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.Faculties.Remove(facultyBeRemoved);
    }
}