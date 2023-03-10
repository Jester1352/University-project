using University.Core.Domain.Teachers.Models;

namespace University.Core.Domain.Teachers.Common;

public interface ITeachersRepository
{
    Teacher Find(Guid id);

    void Add(Teacher teacher);

    void Delete(Guid id);
}