namespace University.Application.Domain.Subject.Commands.RemoveSubject;

public interface IRemoveSubjectCommand
{
    void RemoveSubject(Guid id);
}