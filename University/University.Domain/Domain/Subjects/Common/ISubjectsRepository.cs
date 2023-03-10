using University.Core.Domain.Subjects.Models;

namespace University.Core.Domain.Subjects.Common;

public interface ISubjectsRepository
{
    Subject Find(Guid id);

    void Add(Subject subject);

    void Delete(Guid id);
}