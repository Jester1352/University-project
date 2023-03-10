namespace University.Application.Domain.Teachers.Queries.GetTeacher;

public record TeacherDto
{
    public Guid Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string MiddleName { get; init; }

    public Guid SubjectsId { get; init; }
}