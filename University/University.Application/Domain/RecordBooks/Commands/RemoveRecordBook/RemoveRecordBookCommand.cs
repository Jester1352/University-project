using University.Core.Common;
using University.Core.Domain.RecordBooks.Common;

namespace University.Application.Domain.RecordBooks.Commands.RemoveRecordBook;

public class RemoveRecordBookCommand : IRemoveRecordBookCommand
{
    private readonly IRecordBookRepository _recordBookRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveRecordBookCommand(IRecordBookRepository recordBookRepository, IUnitOfWork unitOfWork)
    {
        _recordBookRepository = recordBookRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveBookCommand(Guid id)
    {
        _recordBookRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}