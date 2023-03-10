namespace University.Application.Domain.Students.Queries.GetStudent;

public record StudentDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public Guid StudentGroupId { get; set; }
}