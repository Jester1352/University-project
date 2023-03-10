namespace University.Application.Domain.Students.Commands.RemoveStudent;

public interface IRemoveStudentCommand
{
    void RemoveStudent(Guid id);
}