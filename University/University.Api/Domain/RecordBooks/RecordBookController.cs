using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.RecordBooks.Requests;
using University.Application.Domain.RecordBooks.Commands;
using University.Application.Domain.RecordBooks.Commands.CreateRecordBook;
using University.Application.Domain.RecordBooks.Commands.RemoveRecordBook;
using University.Application.Domain.RecordBooks.Queries;
using University.Application.Domain.RecordBooks.Queries.GetRecordBook;

namespace University.Api.Domain.RecordBooks
{
    [ApiController]
    [Route(Routs.RecordBooks)]
    public class RecordBookController : ControllerBase
    {
        private readonly IGetRecordBookQuery _getRecordBookQuery;
        private readonly ICreateRecordBookCommand _createRecordBookCommand;
        private readonly IRemoveRecordBookCommand _removeRecordBookCommand;   

        public RecordBookController(
            IGetRecordBookQuery getRecordBookQuery,
            ICreateRecordBookCommand createRecordBookCommand,
            IRemoveRecordBookCommand removeRecordBookCommand
            )
        {
            _getRecordBookQuery = getRecordBookQuery;
            _createRecordBookCommand = createRecordBookCommand;
            _removeRecordBookCommand = removeRecordBookCommand;
        }

        [HttpGet]
        public IEnumerable<RecordBookDto> GetRecordBooks()
        {
            return _getRecordBookQuery.GetRecordBooks();
        }

        [HttpPost]
        public Guid CreateRecordBook([FromBody] CreateRecordBookRequest request)
        {
            var id = _createRecordBookCommand.CreateRecordBook(request.studentId);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveRecordBook([FromBody] RemoveRecordBookRequest request)
        {
            _removeRecordBookCommand.RemoveBookCommand(request.studentId);
            return Guid.NewGuid();
        }
    }
}
