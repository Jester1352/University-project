using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Subject.Queries.GetSubjects;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Subject.Queries;

public class GetSubjectsQuery : IGetSubjectsQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetSubjectsQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public SubjectDto[] GetSubjects(int pageSize, int pageNumber)
    {
        var sqlQuery = _universityDbContext.Subjects.AsNoTracking();
        var skip = (pageNumber - 1) * pageSize;
        var data = sqlQuery
            .OrderBy(subject => subject.Id)
            .Skip(skip)
            .Take(pageSize)
            .Select(subject => new SubjectDto()
            {
                Id = subject.Id,
                Name = subject.Name,
                Code = subject.Code
            })
            .ToArray();
        return data;
    }
}