namespace University.Application.Domain.Students.Queries.GetStudent;

public interface IGetStudentsQuery
{
    StudentDto[] GetStudents(int pageSize, int pageNumber);
}