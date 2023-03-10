using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Departments.Common;

public interface IDepartmentRepository
{
    Department Find(Guid id);

    void Add(Department department);

    void Delete(Guid id);
}