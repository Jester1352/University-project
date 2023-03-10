using University.Core.Common;
using University.Core.Domain.StudentGroups.Common;
using University.Core.Domain.StudentGroups.Models;

namespace University.Application.Domain.StudentGroups.Commands.CreateStudentGroup;

public class CreateStudentGroupCommand : ICreateStudentGroupCommand
{
    private readonly IStudentGroupRepository _studentGroupRepository;

    private readonly IUnitOfWork _unitOfWork;

    public Guid CreateStudentGroup(string name)
    {
        var studentGroup = StudentGroup.Create(name);
        _studentGroupRepository.Add(studentGroup);
        _unitOfWork.SaveChanges();
        return studentGroup.Id;
    }
}