using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.RemoveStudent;

public class RemoveStudentCommand : IRemoveStudentCommand
{
    private readonly IStudentsRepository _studentsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveStudentCommand(IStudentsRepository studentsRepository, IUnitOfWork unitOfWork)
    {
        _studentsRepository = studentsRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveStudent(Guid id)
    {
        _studentsRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}