namespace University.Application.Domain.Faculties.Commands.RemoveFaculty;

public interface IRemoveFacultyCommand
{
    void RemoveFaculty(Guid id);
}