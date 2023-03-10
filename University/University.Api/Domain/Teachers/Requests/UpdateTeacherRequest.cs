namespace University.Api.Domain.Teachers.Requests
{
    public record UpdateTeacherFirstNameRequest(Guid id, string updateFirstName);

    public record UpdateTeacherLastNameRequest(Guid id, string updateLastName);

    public record UpdateteacherMiddleNameRequest(Guid id, string updateMiddleName);
}

