using Digigarage.Business.Interface;
using Digigarage.BusinessEntities;
using Digigarage.Data.Repository;
using Digigarage.Data.Repository.Interface;
using System.Collections.Generic;

namespace Digigarage.Business
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly DepartmentRepostitory _DepartmentRepository;

        public DepartmentManager(DepartmentRepostitory DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public IEnumerable<DepartmentViewModel> GetAllDepartment()
        {
            return _DepartmentRepository.GetAllDepartment();
        }
    }
}
