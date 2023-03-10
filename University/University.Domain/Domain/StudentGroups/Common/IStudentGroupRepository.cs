using University.Core.Domain.StudentGroups.Models;

namespace University.Core.Domain.StudentGroups.Common;

public interface IStudentGroupRepository
{
    StudentGroup Find(Guid id);

    void Add (StudentGroup studentGroup);

    void Delete (Guid id);
}