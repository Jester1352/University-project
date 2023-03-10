using University.Core.Common;
using University.Core.Domain.Departments.Common;

namespace University.Application.Domain.Departments.Commands.RemoveDepartment;

public class RemoveDepartmentCommand : IRemoveDepartmentCommand
{
    private readonly IDepartmentRepository _departmentRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveDepartmentCommand(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveDepartment(Guid id)
    {
        _departmentRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}