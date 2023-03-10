using University.Core.Common;
using University.Core.Domain.Students.Common;

namespace University.Application.Domain.Students.Commands.UpdateStudent;

public class UpdateStudentCommand : IUpdateStudentCommand
{
    private readonly IStudentsRepository _studentsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateStudentCommand(IStudentsRepository studentsRepository, IUnitOfWork unitOfWork)
    {
        _studentsRepository = studentsRepository;
        _unitOfWork = unitOfWork;
    }

    public void UpdateStudentFirstName(Guid id, string updateFirstName)
    {
        var student = _studentsRepository.Find(id);
        student.FirstName = updateFirstName;
        _unitOfWork.SaveChanges();
    }

    public void UpdateStudentLastName(Guid id, string updateLastName)
    {
        var student = _studentsRepository.Find(id);
        student.LastName = updateLastName;
        _unitOfWork.SaveChanges();
    }

    public void UpdateStudentMiddleName(Guid id, string updateMiddleName)
    {
        var student = _studentsRepository.Find(id);
        student.MiddleName = updateMiddleName;
        _unitOfWork.SaveChanges();
    }
}