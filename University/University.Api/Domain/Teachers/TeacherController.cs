using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.Subjects.Requests;
using University.Api.Domain.Teachers.Requests;
using University.Application.Domain.Subject.Queries.GetSubjects;
using University.Application.Domain.Teachers.Commands;
using University.Application.Domain.Teachers.Commands.CreateTeacher;
using University.Application.Domain.Teachers.Commands.RemoveTeacher;
using University.Application.Domain.Teachers.Commands.UpdateTeacher;
using University.Application.Domain.Teachers.Queries;
using University.Application.Domain.Teachers.Queries.GetTeacher;

namespace University.Api.Domain.Teachers
{
    [ApiController]
    [Route(Routs.Teachers)]
    public class TeacherController : ControllerBase
    {
        private readonly IGetTeachersQuery _getTeachersQuery;
        private readonly ICreateTeacherCommand _createTeacherCommand;
        private readonly IRemoveTeacherCommand _removeTeacherCommand;
        private readonly IUpdateTeacherCommand _updateTeacherCommand;
        public TeacherController(
            IGetTeachersQuery getTeachersQuery,
            ICreateTeacherCommand createTeacherCommand,
            IRemoveTeacherCommand removeTeacherCommand,
            IUpdateTeacherCommand updateTeacherCommand
            )
        {
            _getTeachersQuery = getTeachersQuery;
            _createTeacherCommand = createTeacherCommand;
            _removeTeacherCommand = removeTeacherCommand;
            _updateTeacherCommand = updateTeacherCommand;
        }

        [HttpGet]
        public IEnumerable<TeacherDto> GetTeachers()
        {
            return _getTeachersQuery.GetTeachers();
        }

        [HttpPost]
        public Guid CreateTeacher([FromBody] CreateTeacherRequest request)
        {
            var id = _createTeacherCommand.CreateTeacher(request.firstName, request.lastName, request.middleName);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveTeacher([FromBody] RemoveTeacherRequest request)
        {
            _removeTeacherCommand.RemoveTeacher(request.id);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/teachers/patchFirstName")]
        public Guid UpdateTeacherFirstName([FromBody] UpdateTeacherFirstNameRequest request)
        {
            _updateTeacherCommand.UpdateTeacherFirstName(request.id, request.updateFirstName);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/teachers/patchLastName")]
        public Guid UpdateTeacherLastName([FromBody] UpdateTeacherLastNameRequest request)
        {
            _updateTeacherCommand.UpdateTeacherLastName(request.id, request.updateLastName);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/teachers/patchMiddleName")]
        public Guid UpdateTeacherMiddleName([FromBody] UpdateteacherMiddleNameRequest request)
        {
            _updateTeacherCommand.UpdateTeacherMiddleName(request.id, request.updateMiddleName);
            return Guid.NewGuid();
        }
    }
}

