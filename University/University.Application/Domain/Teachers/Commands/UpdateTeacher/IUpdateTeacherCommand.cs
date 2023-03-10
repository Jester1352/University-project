namespace University.Application.Domain.Teachers.Commands.UpdateTeacher;

public interface IUpdateTeacherCommand
{
    void UpdateTeacherFirstName(Guid id, string updateFirstName);

    void UpdateTeacherLastName(Guid id, string updateLastName);

    void UpdateTeacherMiddleName(Guid id, string updateMiddleName);
}