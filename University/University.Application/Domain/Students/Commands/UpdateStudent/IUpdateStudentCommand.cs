namespace University.Application.Domain.Students.Commands.UpdateStudent;

public interface IUpdateStudentCommand
{
    void UpdateStudentFirstName(Guid id, string updateFirstName);

    void UpdateStudentLastName(Guid id, string updateLastName);

    void UpdateStudentMiddleName(Guid id, string updateMiddleName);
}