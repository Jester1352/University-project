namespace University.Application.Domain.Subject.Queries.GetSubjects;

public interface IGetSubjectsQuery
{
    SubjectDto[] GetSubjects(int pageSize, int pageNumber);
}