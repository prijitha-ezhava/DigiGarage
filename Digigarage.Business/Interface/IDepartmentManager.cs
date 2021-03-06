using Digigarage.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.Business.Interface
{
    public interface IDepartmentManager
    {
        IEnumerable<DepartmentViewModel> GetAllDepartment();
    }
}
