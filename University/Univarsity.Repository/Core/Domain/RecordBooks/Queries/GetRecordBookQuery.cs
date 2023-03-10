using Microsoft.EntityFrameworkCore;
using University.Application.Domain.RecordBooks.Queries.GetRecordBook;
using University.Persistence.UniversityDb;

namespace University.Infrastructure.Core.Domain.RecordBooks.Queries;

public class GetRecordBookQuery : IGetRecordBookQuery
{
    private readonly UniversityDbContext _universityDbContext;

    public GetRecordBookQuery(UniversityDbContext universityDbContext)
    {
        _universityDbContext = universityDbContext;
    }


    public RecordBookDto[] GetRecordBooks()
    {
        var sqlQuery = _universityDbContext
            .RecordBooks
            .Join(_universityDbContext.RecordBooksSubjects, x => x.Id, x => x.SubjectId,
                (recordBook, recordBookSubject) => new
                {
                    RecordBook = recordBook,
                    RecordBookSubject = recordBookSubject,
                })
            .AsNoTracking()
            .ToArray();

        var recordBookDttos = sqlQuery.Select(x => new RecordBookDto()
        {
            Id = x.RecordBook.Id,
            SubjectId = x.RecordBookSubject.SubjectId,
            StudentId = x.RecordBook.StudentId
        }).ToArray();

        return recordBookDttos;
    }
}