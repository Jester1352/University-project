using University.Core.Domain.Departments.Models;

namespace University.Core.Domain.Faculties.Models;

public class FacultyDepartment
{
    private FacultyDepartment()
    {

    }

    public Guid FacultyId { get; set; }

    public Guid DepartmenttId { get; set; }

    public Department Department { get; set; }
}