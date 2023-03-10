using University.Core.Common;
using University.Core.Domain.Students.Common;
using University.Core.Domain.Students.Models;

namespace University.Application.Domain.Students.Commands.CreateStudent;

public class CreateStudentCommand : ICreateStudentCommand
{
    private readonly IStudentsRepository _studentsRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateStudentCommand(IStudentsRepository studentsRepository, IUnitOfWork unitOfWork)
    {
        _studentsRepository = studentsRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateStudent(string firstName, string lastName, string middleName, Guid groupId)
    {
        var student = Student.Create(firstName, lastName, middleName, groupId);
        _studentsRepository.Add(student);
        _unitOfWork.SaveChanges();
        return student.Id;
    }
}