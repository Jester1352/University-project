using University.Core.Common;
using University.Core.Domain.Teachers.Common;

namespace University.Application.Domain.Teachers.Commands.UpdateTeacher;

public class UpdateTeacherCommand : IUpdateTeacherCommand
{
    private readonly ITeachersRepository _teachersRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateTeacherCommand(ITeachersRepository teachersRepository, IUnitOfWork unitOfWork)
    {
        _teachersRepository = teachersRepository;
        _unitOfWork = unitOfWork;
    }

    public void UpdateTeacherFirstName(Guid id, string updateFirstName)
    {
        var teacher = _teachersRepository.Find(id);
        teacher.FirstName = updateFirstName;
        _unitOfWork.SaveChanges();
    }

    public void UpdateTeacherLastName(Guid id, string updateLastName)
    {
        var teacher = _teachersRepository.Find(id);
        teacher.LastName = updateLastName;
        _unitOfWork.SaveChanges();
    }

    public void UpdateTeacherMiddleName(Guid id, string updateMiddleName)
    {
        var teacher = _teachersRepository.Find(id);
        teacher.MiddleName = updateMiddleName;
        _unitOfWork.SaveChanges();
    }
}