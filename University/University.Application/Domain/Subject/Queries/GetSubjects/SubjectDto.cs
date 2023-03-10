namespace University.Application.Domain.Subject.Queries.GetSubjects;

public record SubjectDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Code { get; set; }
}