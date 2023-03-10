using University.Core.Common;
using University.Core.Domain.Subjects.Common;

namespace University.Application.Domain.Subject.Commands.RemoveSubject;

public class RemoveSubjectCommand : IRemoveSubjectCommand
{
    private readonly ISubjectsRepository _subjectsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveSubjectCommand(ISubjectsRepository subjectsRepository, IUnitOfWork unitOfWork)
    {
        _subjectsRepository = subjectsRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveSubject(Guid id)
    {
        _subjectsRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}