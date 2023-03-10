using University.Core.Common;
using University.Core.Domain.Teachers.Common;

namespace University.Application.Domain.Teachers.Commands.RemoveTeacher;

public class RemoveTeacherCommand : IRemoveTeacherCommand
{
    private readonly ITeachersRepository _teachersRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveTeacherCommand(ITeachersRepository teachersRepository, IUnitOfWork unitOfWork)
    {
        _teachersRepository = teachersRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveTeacher(Guid id)
    {
        _teachersRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}