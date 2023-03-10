using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.Faculties.Requests;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.Application.Domain.Faculties.Commands;
using University.Application.Domain.Faculties.Commands.CreateFaculty;
using University.Application.Domain.Faculties.Commands.RemoveFaculty;
using University.Application.Domain.Faculties.Queries;
using University.Application.Domain.Faculties.Queries.GetFaculty;

namespace University.Api.Domain.Faculties
{
    [ApiController]
    [Route(Routs.Faculties)]
    public class FacultyController : ControllerBase
    {
        private readonly IGetFacultyQuery _getFacultyQuery;
        private readonly IRemoveFacultyCommand _removeFacultyCommand;
        private readonly ICreateFacultyCommand _createFacultyCommand;

        public FacultyController(
            IGetFacultyQuery getFacultyQuery,
            IRemoveFacultyCommand removeFacultyCommand,
            ICreateFacultyCommand createFacultyCommand
            )
        {
            _getFacultyQuery = getFacultyQuery;
            _removeFacultyCommand = removeFacultyCommand;
            _createFacultyCommand = createFacultyCommand;
        }

        [HttpGet]
        public IEnumerable<FacultyDto> GetFaculties(int pageSize, int pageNumber)
        {
            return _getFacultyQuery.GetFaculty(pageSize, pageNumber);
        }

        [HttpPost]
        public Guid CreateFaculty([FromBody] CreateFacultyRequest request)
        {
            var id = _createFacultyCommand.CreateFaculty(request.name);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveFaculty([FromBody] RemoveFacultyRequest request)
        {
            _removeFacultyCommand.RemoveFaculty(request.id);
            return Guid.NewGuid();
        }
    }
}
