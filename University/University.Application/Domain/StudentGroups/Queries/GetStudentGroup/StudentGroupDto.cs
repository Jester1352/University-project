namespace University.Application.Domain.StudentGroups.Queries.GetStudentGroup;

public record StudentGroupDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}