using Microsoft.EntityFrameworkCore;
using University.Application.Domain.StudentGroups.Queries.GetStudentGroup;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.StudentGroups.Queries;

public class GetStudentGroupQuery : IGetStudentGroupQuery
{
    private readonly UniversityDbContext _universityDbContext;

   public GetStudentGroupQuery(UniversityDbContext universityDbContext)
   {
        _universityDbContext = universityDbContext;
   }

    public StudentGroupDto[] GetGroups(int pageSize, int pageNumber)
    {
        var sqlQuery = _universityDbContext.StudentGroups.AsNoTracking();
        var skip = (pageNumber - 1) * pageSize;
        var data = sqlQuery
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(pageSize)
            .Select(x => new StudentGroupDto()
            {
                Id = x.Id,
                Name = x.Name,
            })
            .ToArray();
        return data;
    }
}