using University.Core.Domain.Students.Models;

namespace University.Core.Domain.Students.Common;

public interface IStudentsRepository
{
    Student Find(Guid id);

    void Add(Student student);

    void Delete(Guid id);
}