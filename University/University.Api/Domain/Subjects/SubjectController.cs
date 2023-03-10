using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.Subjects.Requests;
using University.Application.Domain.Subject.Commands.CreateSubject;
using University.Application.Domain.Subject.Commands.RemoveSubject;
using University.Application.Domain.Subject.Commands.UpdateSubject;
using University.Application.Domain.Subject.Queries.GetSubjects;


namespace University.Api.Domain.Subjects
{
    [ApiController]
    [Route(Routs.Subjects)]
    public class SubjectController : ControllerBase
    {
        private readonly IGetSubjectsQuery _subjectsQuery;
        private readonly ICreateSubjectCommand _createSubjectCommand;
        private readonly IRemoveSubjectCommand _removeSubjectCommand;
        private readonly IUpdateSubjectCommand _updateSubjectCommand;

        public SubjectController(
            IGetSubjectsQuery subjectsQuery,
            ICreateSubjectCommand createSubjectCommand,
            IRemoveSubjectCommand removeSubjectCommand,
            IUpdateSubjectCommand updateSubjectCommand
            )
        {
            _subjectsQuery = subjectsQuery;
            _createSubjectCommand = createSubjectCommand;
            _removeSubjectCommand = removeSubjectCommand;
            _updateSubjectCommand = updateSubjectCommand;
        }

        [HttpGet]
        public IEnumerable<SubjectDto>GetSubjects(int pageSize, int page)
        {
            return _subjectsQuery.GetSubjects(pageSize, page);
        }

        [HttpPost]
        public Guid CreateSubject([FromBody]CreateSubjectRequest request)
        {
            var id = _createSubjectCommand.CreateSubject(request.Name, request.Code);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveSubject([FromBody] RemoveSubjectRequest request)
        {
            _removeSubjectCommand.RemoveSubject(request.Id);
            return Guid.NewGuid();
        }

        [HttpPatch]
        public Guid UpdateSubject([FromBody] UpdateSubjectRequest request)
        {
            _updateSubjectCommand.UpdateSubject(request.Id, request.updateName);
            return Guid.NewGuid();
        }
    }
}
