namespace University.Application.Domain.Faculties.Queries.GetFaculty;

public interface IGetFacultyQuery
{
    FacultyDto[] GetFaculty(int pageSize, int pageNumber);
}