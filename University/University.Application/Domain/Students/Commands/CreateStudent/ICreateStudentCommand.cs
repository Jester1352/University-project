namespace University.Application.Domain.Students.Commands.CreateStudent;

public interface ICreateStudentCommand
{
    Guid CreateStudent(string firstName, string lastName, string middleName, Guid groupId);
}