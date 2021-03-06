using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class DepartmentViewModel
    {
        public int DeptId { get; set; }
        [DisplayName("Department")]
        public string Department1 { get; set; }
    }
}
