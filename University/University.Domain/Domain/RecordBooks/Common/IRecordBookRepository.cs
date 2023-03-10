using University.Core.Domain.RecordBooks.Models;

namespace University.Core.Domain.RecordBooks.Common;

public interface IRecordBookRepository
{
    RecordBook Find(Guid id);
    
    void Add(RecordBook recordBook);

    void Delete(Guid id);
}