namespace University.Application.Domain.Teachers.Queries.GetTeacher;

public interface IGetTeachersQuery
{
    TeacherDto[] GetTeachers();
}