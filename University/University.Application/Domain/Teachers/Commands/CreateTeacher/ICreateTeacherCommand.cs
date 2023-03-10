namespace University.Application.Domain.Teachers.Commands.CreateTeacher;

public interface ICreateTeacherCommand
{
    Guid CreateTeacher(string firstName, string lastName, string middleName);
}