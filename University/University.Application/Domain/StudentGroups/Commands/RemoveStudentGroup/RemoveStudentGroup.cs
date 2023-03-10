using University.Core.Common;
using University.Core.Domain.StudentGroups.Common;

namespace University.Application.Domain.StudentGroups.Commands.RemoveStudentGroup
{
    public class RemoveStudentGroup : IRemoveStudentGroup
    {
        private readonly IStudentGroupRepository _studentGroupRepository;

        private readonly IUnitOfWork _unitOfWork;

        public void RemoveGroup(Guid id)
        {
            _studentGroupRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}
