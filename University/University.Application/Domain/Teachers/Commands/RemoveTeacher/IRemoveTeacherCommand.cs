namespace University.Application.Domain.Teachers.Commands.RemoveTeacher;

public interface IRemoveTeacherCommand
{
    void RemoveTeacher(Guid id);
}