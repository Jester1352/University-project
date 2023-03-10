namespace University.Api.Domain.Student.Requests;

public record CreateStudentRequest(string firstName, string lastName, string middleName, Guid groupId);