using University.Core.Domain.RecordBooks.Common;
using University.Core.Domain.RecordBooks.Models;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.RecordBooks.Common;

public class RecordBookRepository : IRecordBookRepository
{
    private readonly UniversityDbContext _universityDbContext;

    public RecordBookRepository(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }

    public RecordBook Find(Guid id)
    {
        var recordBook = _universityDbContext.RecordBooks.SingleOrDefault(x => x.Id == id);
        return recordBook ?? throw new InvalidOperationException();
    }

    public void Add(RecordBook recordBook)
    {
        _universityDbContext.RecordBooks.Add(recordBook);
    }

    public void Delete(Guid id)
    {
        var recordBookToBeRemoved = _universityDbContext.RecordBooks.SingleOrDefault(x => x.Id == id);
        if (recordBookToBeRemoved is null) throw new InvalidOperationException();
        _universityDbContext.RecordBooks.Remove(recordBookToBeRemoved);
    }
}