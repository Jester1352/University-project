namespace University.Application.Domain.Faculties.Commands.CreateFaculty;

public interface ICreateFacultyCommand
{
    Guid CreateFaculty(string name);
}