using University.Core.Common;
using University.Core.Domain.Faculties.Common;

namespace University.Application.Domain.Faculties.Commands.RemoveFaculty;

public class RemoveFacultyCommand : IRemoveFacultyCommand
{
    private readonly IFacultyRepository _facultyRepository;

    private readonly IUnitOfWork _unitOfWork;

    public RemoveFacultyCommand(IFacultyRepository facultyRepository, IUnitOfWork unitOfWork)
    {
        _facultyRepository = facultyRepository;
        _unitOfWork = unitOfWork;
    }

    public void RemoveFaculty(Guid id)
    {
        _facultyRepository.Delete(id);
        _unitOfWork.SaveChanges();
    }
}