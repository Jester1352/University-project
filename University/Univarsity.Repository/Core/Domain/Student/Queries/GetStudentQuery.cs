using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Students.Queries.GetStudent;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Student.Queries;

public class GetStudentQuery : IGetStudentsQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetStudentQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public StudentDto[] GetStudents(int pageSize, int pageNumber)
    {
        var sqlQuery = _universityDbContext.Students.AsNoTracking();
        var skip = (pageNumber - 1) * pageSize;
        var data = sqlQuery
            .OrderBy(student => student.Id)
            .Skip(skip)
            .Take(pageSize)
            .Select(student => new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                StudentGroupId = student.GroupId
            })
            .ToArray();
        return data;
    }
}