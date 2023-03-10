namespace University.Api.Domain.Students.Requests
{
    public record UpdateStudentFirstNameRequest(Guid id, string updateFirstName);

    public record UpdateStudentLastNameRequest(Guid id, string updateLastName);

    public record UpdateStudentMiddleNameRequest(Guid id, string updateMiddleName);
}
