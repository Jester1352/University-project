using University.Core.Domain.StudentGroups.Common;
using University.Core.Domain.StudentGroups.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.StudentGroups.Common;

public class StudentGroupRepository : IStudentGroupRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public StudentGroup Find(Guid id)
    {
        var studentGroup = _universityDbContext.StudentGroups.SingleOrDefault(x => x.Id == id);
        
        return studentGroup ?? throw new InvalidOperationException();
    }

    public void Add(StudentGroup studentGroup)
    {
        _universityDbContext.StudentGroups.Add(studentGroup);
    }

    public void Delete(Guid id)
    {
        var studentGroupToBeRemove = _universityDbContext.StudentGroups.SingleOrDefault(x => x.Id == id);
        if (studentGroupToBeRemove is null) throw new InvalidOperationException();
        _universityDbContext.StudentGroups.Remove(studentGroupToBeRemove);
    }
}