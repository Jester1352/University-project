using University.Core.Common;
using University.Core.Domain.Subjects.Common;

namespace University.Application.Domain.Subject.Commands.CreateSubject;

public class CreateSubjectCommand : ICreateSubjectCommand
{
    private readonly ISubjectsRepository _subjectsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateSubjectCommand(ISubjectsRepository subjectsRepository, IUnitOfWork unitOfWork)
    {
        _subjectsRepository = subjectsRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateSubject(string name, int code)
    {
        var subject = Core.Domain.Subjects.Models.Subject.Create(name, code);
        _subjectsRepository.Add(subject);
        _unitOfWork.SaveChanges();
        return subject.Id;
    }
}