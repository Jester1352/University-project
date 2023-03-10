namespace University.Application.Domain.RecordBooks.Queries.GetRecordBook;

public record RecordBookDto
{
    public Guid Id { get; init; }

    public Guid StudentId { get; init; }

    public Guid SubjectId { get; init; }
}