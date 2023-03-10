using MediatR;
using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.Subjects.Requests;
using University.Application.Domain.Students.Queries.GetStudent;
using University.Application.Domain.Students.Commands.CreateStudent;
using University.Application.Domain.Students.Commands.RemoveStudent;
using University.Api.Domain.Student.Requests;
using University.Api.Domain.Students.Requests;
using University.Application.Domain.Students.Commands.UpdateStudent;

namespace University.Api.Domain.Students
{
    [ApiController]
    [Route(Routs.Students)]
    public class StudentController : ControllerBase
    {
        private readonly IGetStudentsQuery _studentsQuery;
        private readonly ICreateStudentCommand _createStudentCommand;
        private readonly IRemoveStudentCommand _removeStudentCommand;
        private readonly IUpdateStudentCommand _updateStudentCommand;

        public StudentController(
            IGetStudentsQuery studentsQuery,
            ICreateStudentCommand createStudentCommand,
            IRemoveStudentCommand removeStudentCommand,
            IUpdateStudentCommand updateStudentCommand
            )
        {
            _studentsQuery = studentsQuery;
            _createStudentCommand = createStudentCommand;
            _removeStudentCommand = removeStudentCommand;
            _updateStudentCommand = updateStudentCommand;
        }

        [HttpGet]
        public IEnumerable<StudentDto> GetStudents(int pageSize, int page)
        {
            return _studentsQuery.GetStudents(pageSize, page);
        }

        [HttpPost]
        public Guid CreateStudent([FromBody] CreateStudentRequest request)
        {
            var id = _createStudentCommand.CreateStudent(request.firstName, request.lastName, request.middleName, request.groupId);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveStudent([FromBody] RemoveStudentRequest request)
        {
            _removeStudentCommand.RemoveStudent(request.Id);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/students/patchFirstName")]
        public Guid UpdateStudentFirstName([FromBody] UpdateStudentFirstNameRequest reqest)
        {
            _updateStudentCommand.UpdateStudentFirstName(reqest.id, reqest.updateFirstName);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/students/patchLastName")]
        public Guid UpdateStudentLastName([FromBody] UpdateStudentLastNameRequest reqest)
        {
            _updateStudentCommand.UpdateStudentLastName(reqest.id, reqest.updateLastName);
            return Guid.NewGuid();
        }

        [HttpPatch("~/api/students/patchMiddleName")]
        public Guid UpdateStudentMiddleName([FromBody] UpdateStudentMiddleNameRequest reqest)
        {
            _updateStudentCommand.UpdateStudentMiddleName(reqest.id, reqest.updateMiddleName);
            return Guid.NewGuid();
        }
    }
}