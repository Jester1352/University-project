namespace University.Application.Domain.StudentGroups.Queries.GetStudentGroup;

public interface IGetStudentGroupQuery
{
    StudentGroupDto[] GetGroups(int pageSize, int pageNumber);
}