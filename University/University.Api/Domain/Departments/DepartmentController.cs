using Microsoft.AspNetCore.Mvc;
using University.Api.Domain.Common;
using University.Api.Domain.Departments.Requests;
using University.Application.Domain.Departments.Commands;
using University.Application.Domain.Departments.Commands.CreateDepartment;
using University.Application.Domain.Departments.Commands.RemoveDepartment;
using University.Application.Domain.Departments.Queries;
using University.Application.Domain.Departments.Queries.GetDepartment;

namespace University.Api.Domain.Departments
{
    [ApiController]
    [Route(Routs.Departments)]
    public class DepartmentController : ControllerBase
    {
        private readonly IGetDepartmentQuery _getDepartmentQuery;
        private readonly ICreateDepartmentCommand _createDepartmentCommand;
        private readonly IRemoveDepartmentCommand _removeDepartmentCommand;

        public DepartmentController(
            IGetDepartmentQuery getDepartmentQuery,
            ICreateDepartmentCommand createDepartmentCommand,
            IRemoveDepartmentCommand removeDepartmentCommand

            )
        {
            _getDepartmentQuery = getDepartmentQuery;
            _createDepartmentCommand = createDepartmentCommand;
            _removeDepartmentCommand = removeDepartmentCommand;
        }

        [HttpGet]
        public IEnumerable<DepartmentDto> GetDepartment()
        {
            return _getDepartmentQuery.GetDepartment();
        }

        [HttpPost]
        public Guid CreateDepartment([FromBody] CreateDepartmentRequest request)
        {
            var id = _createDepartmentCommand.CreateDepartment(request.name);
            return Guid.NewGuid();
        }

        [HttpDelete]
        public Guid RemoveDepartment([FromBody] RemoveDepartmentRequest request)
        {
            _removeDepartmentCommand.RemoveDepartment(request.id);
            return Guid.NewGuid();
        }
    }
}
