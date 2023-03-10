namespace University.Application.Domain.Departments.Commands.CreateDepartment;

public interface ICreateDepartmentCommand
{
    Guid CreateDepartment(string name);
}