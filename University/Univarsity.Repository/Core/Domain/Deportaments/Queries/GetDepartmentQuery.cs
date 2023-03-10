using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Departments.Queries.GetDepartment;
using University.Application.Domain.Teachers.Queries.GetTeacher;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Deportaments.Queries;

public class GetDepartmentQuery : IGetDepartmentQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetDepartmentQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public DepartmentDto[] GetDepartment()
    {
        var sqlQuery = _universityDbContext
            .Departments
            .Join(_universityDbContext.FacultyDepartments, x => x.Id, x => x.DepartmenttId,
                (department, facultyDepartment) => new
                {
                    Department = department,
                    FacultyDepartment = facultyDepartment
                })
            .AsNoTracking()
            .ToArray();

        var departmentDtos = sqlQuery.Select(x => new DepartmentDto()
        {
            Id = x.Department.Id,
            Name = x.Department.Name,
            FacultyId = x.FacultyDepartment.FacultyId
            
        }).ToArray();

        return departmentDtos;
    }
}