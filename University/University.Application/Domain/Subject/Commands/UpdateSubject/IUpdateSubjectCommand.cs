namespace University.Application.Domain.Subject.Commands.UpdateSubject;

public interface IUpdateSubjectCommand
{
    void UpdateSubject(Guid id, string updateName);
}