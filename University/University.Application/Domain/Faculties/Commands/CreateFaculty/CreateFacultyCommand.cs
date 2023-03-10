using University.Core.Common;
using University.Core.Domain.Faculties.Common;
using University.Core.Domain.Faculties.Models;

namespace University.Application.Domain.Faculties.Commands.CreateFaculty;

public class CreateFacultyCommand : ICreateFacultyCommand
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFacultyCommand(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
    {
        _facultyRepository = facultyRepository;
        _unitOfWork = unitOfWork;
    }

    public Guid CreateFaculty(string name)
    {
        var faculty = Faculty.Create(name);
        _facultyRepository.Add(faculty);
        _unitOfWork.SaveChanges();
        return faculty.Id;
    }
}