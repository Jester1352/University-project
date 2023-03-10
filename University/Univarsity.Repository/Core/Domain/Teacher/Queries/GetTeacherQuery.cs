using Microsoft.EntityFrameworkCore;
using University.Application.Domain.Teachers.Queries.GetTeacher;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.Teacher.Queries;

public class GetTeacherQuery : IGetTeachersQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetTeacherQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public TeacherDto[] GetTeachers()
    {
        var sqlQuery = _universityDbContext
            .Teachers
            .Join(_universityDbContext.TeachersSubjects, x => x.Id, x => x.TeacherId,
                (teacher, teacherSubject) => new
                {
                    Teacher = teacher,
                    TeacherSubject = teacherSubject
                })
            .AsNoTracking()
            .ToArray();

        var teacherDtos = sqlQuery.Select(x => new TeacherDto()
        {
            Id = x.Teacher.Id,
            FirstName = x.Teacher.FirstName,
            LastName = x.Teacher.LastName,
            MiddleName = x.Teacher.MiddleName,
            SubjectsId = x.TeacherSubject.SubjectId
        }).ToArray();

        return teacherDtos;
    }
}