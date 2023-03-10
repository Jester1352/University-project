namespace University.Application.Domain.Departments.Commands.RemoveDepartment;

public interface IRemoveDepartmentCommand
{
    void RemoveDepartment(Guid id);
}