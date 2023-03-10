using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Faculties.Queries.GetFaculty;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Faculties.Queries;

public class GetFacultyQuery : IGetFacultyQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetFacultyQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public FacultyDto[] GetFaculty(int pageSize, int pageNumber)
    {
        var sqlQuery = _universityDbContext.Faculties.AsNoTracking();
        var skip = (pageNumber - 1) * pageSize;
        var data = sqlQuery
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(pageSize)
            .Select(x => new FacultyDto()
            {
                Id = x.Id,
               Name = x.Name
            })
            .ToArray();
        return data;
    }
}