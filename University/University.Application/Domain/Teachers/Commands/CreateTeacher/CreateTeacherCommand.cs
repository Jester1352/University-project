using University.Core.Common;
using University.Core.Domain.Teachers.Common;
using University.Core.Domain.Teachers.Models;

namespace University.Application.Domain.Teachers.Commands.CreateTeacher;

public class CreateTeacherCommand : ICreateTeacherCommand
{
    private readonly ITeachersRepository _teachersRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateTeacherCommand(ITeachersRepository teachersRepository, IUnitOfWork unitOfWork)
    {
        _teachersRepository = teachersRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateTeacher(string firstName, string lastName, string middleName)
    {
        var teacher = Teacher.Create(firstName, lastName, middleName);
        _teachersRepository.Add(teacher);
        _unitOfWork.SaveChanges();
        return teacher.Id;
    }
}