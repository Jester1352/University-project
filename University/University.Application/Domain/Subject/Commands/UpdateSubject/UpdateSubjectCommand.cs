using University.Core.Common;
using University.Core.Domain.Subjects.Common;

namespace University.Application.Domain.Subject.Commands.UpdateSubject;

public class UpdateSubjectCommand : IUpdateSubjectCommand
{
    private readonly ISubjectsRepository _subjectsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateSubjectCommand(ISubjectsRepository subjectsRepository, IUnitOfWork unitOfWork)
    {
        _subjectsRepository = subjectsRepository;
        _unitOfWork = unitOfWork;
    }

    public void UpdateSubject(Guid id, string updateName)
    {
        var subject = _subjectsRepository.Find(id);
        subject.Name = updateName;
        _unitOfWork.SaveChanges();
    }
}