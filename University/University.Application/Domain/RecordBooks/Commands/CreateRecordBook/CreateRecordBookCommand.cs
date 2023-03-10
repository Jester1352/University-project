using University.Core.Common;
using University.Core.Domain.RecordBooks.Common;
using University.Core.Domain.RecordBooks.Models;

namespace University.Application.Domain.RecordBooks.Commands.CreateRecordBook;

public class CreateRecordBookCommand : ICreateRecordBookCommand
{
    private readonly IRecordBookRepository _recordBookRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateRecordBookCommand(IRecordBookRepository recordBookRepository, IUnitOfWork unitOfWork)
    {
        _recordBookRepository = recordBookRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateRecordBook(Guid studentId)
    {
        var recordBook = RecordBook.Create(studentId);
        _recordBookRepository.Add(recordBook);
        _unitOfWork.SaveChanges();
        return recordBook.Id;
    }
}