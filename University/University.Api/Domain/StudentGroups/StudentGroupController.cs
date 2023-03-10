using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.RecordBooks.Requests;
using University.Api.Domain.StudentGroups.Requests;
using University.Application.Domain.RecordBooks.Queries.GetRecordBook;
using University.Application.Domain.StudentGroups.Commands;
using University.Application.Domain.StudentGroups.Commands.CreateStudentGroup;
using University.Application.Domain.StudentGroups.Commands.RemoveStudentGroup;
using University.Application.Domain.StudentGroups.Queries;
using University.Application.Domain.StudentGroups.Queries.GetStudentGroup;

namespace University.Api.Domain.StudentGroups
{
    [ApiController]
    [Route(Routs.StudentGroups)]
    public class StudentGroupController : ControllerBase
    {
        private readonly IGetStudentGroupQuery _getStudentGroupQuery;
        private readonly ICreateStudentGroupCommand _createStudentGroupCommand;
        private readonly IRemoveStudentGroup _removeStudentGroup;

        public StudentGroupController(
            IGetStudentGroupQuery getStudentGroupQuery,
            ICreateStudentGroupCommand createStudentGroupCommand,
            IRemoveStudentGroup removeStudentGroup
            )
        {
            _getStudentGroupQuery = getStudentGroupQuery;
            _createStudentGroupCommand = createStudentGroupCommand;
            _removeStudentGroup = removeStudentGroup;
        }

        [HttpGet]
        public IEnumerable<StudentGroupDto> GetStudentGroup(int pageSize, int pageNumber)
        {
            return _getStudentGroupQuery.GetGroups(pageSize, pageNumber);
        }

        [HttpPost]
        public Guid CreateStudentGroup([FromBody] CreateStudentGroupRequest request)
        {
            var id = _createStudentGroupCommand.CreateStudentGroup(request.name);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveStudentGroup([FromBody] RemoveStudentGroupRequest request)
        {
            _removeStudentGroup.RemoveGroup(request.id);
            return Guid.NewGuid();
        }
    }
}
