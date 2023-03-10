using University.Core.Common;
using University.Core.Domain.Departments.Common;
using University.Core.Domain.Departments.Models;

namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public class CreateDepartmentCommand : ICreateDepartmentCommand
{
    private readonly IDepartmentRepository _departmentRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateDepartmentCommand(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateDepartment(string name)
    {
        var department = Department.Create(name);
        _departmentRepository.Add(department);
        _unitOfWork.SaveChanges();
        return department.Id;
    }
}