using University.Core.Domain.Faculties.Models;

namespace University.Core.Domain.Faculties.Common;

public interface IFacultyRepository
{
    Faculty Find(Guid id);

    void Add(Faculty faculty);

    void Delete(Guid id);
}