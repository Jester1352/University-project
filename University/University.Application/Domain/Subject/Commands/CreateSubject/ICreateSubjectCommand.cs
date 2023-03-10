namespace University.Application.Domain.Subject.Commands.CreateSubject;

public interface ICreateSubjectCommand
{
    Guid CreateSubject(string name, int code);
}