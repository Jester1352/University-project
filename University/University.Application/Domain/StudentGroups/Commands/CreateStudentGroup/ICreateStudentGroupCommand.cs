namespace University.Application.Domain.StudentGroups.Commands.CreateStudentGroup;

public interface ICreateStudentGroupCommand
{
    Guid CreateStudentGroup(string name);
}