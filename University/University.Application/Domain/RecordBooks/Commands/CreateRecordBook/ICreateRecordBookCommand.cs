namespace University.Application.Domain.RecordBooks.Commands.CreateRecordBook;

public interface ICreateRecordBookCommand
{
    Guid CreateRecordBook(Guid studentId);
}