namespace University.Application.Domain.RecordBooks.Commands.RemoveRecordBook;

public interface IRemoveRecordBookCommand
{
    void RemoveBookCommand(Guid id);
}