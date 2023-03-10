using University.Core.Domain.Subjects.Common;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Subject.Common;

public class SubjectsRepository : ISubjectsRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public SubjectsRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public University.Core.Domain.Subjects.Models.Subject Find(Guid id)
    {
        var subject = _universityDbContext.Subjects.SingleOrDefault(x => x.Id == id);

        return subject ?? throw new InvalidOperationException();
    }

    public void Add(University.Core.Domain.Subjects.Models.Subject subject)
    {
        _universityDbContext.Subjects.Add(subject);
    }

    public void Delete(Guid id)
    {
        var subjectToBeRemoved = _universityDbContext.Subjects.SingleOrDefault(subject => subject.Id == id);
        if (subjectToBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.Subjects.Remove(subjectToBeRemoved);
    }
}