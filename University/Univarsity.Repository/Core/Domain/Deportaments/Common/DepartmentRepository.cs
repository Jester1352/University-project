using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Deportaments.Common;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public DepartmentRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public Department Find(Guid id)
    {
        var department = _universityDbContext.Departments.SingleOrDefault(x => x.Id == id);
        return department ?? throw new InvalidOperationException();
    }

    public void Add(Department department)
    {
        _universityDbContext.Departments.Add(department);
    }

    public void Delete(Guid id)
    {
        var departmentBeRemoved = _universityDbContext.Departments.SingleOrDefault(x => x.Id == id);
        if (departmentBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.Departments.Remove(departmentBeRemoved);
    }
}