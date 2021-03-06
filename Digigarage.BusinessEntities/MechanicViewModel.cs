using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class MechanicViewModel
    {
        public int MechanicId { get; set; }
        [Required]
        [DisplayName("Mechanic Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Mobile")]
        [MinLength(10, ErrorMessage = "Phone no greater than 10 digit")]
        [MaxLength(10, ErrorMessage = "Phone no less than 10 digit")]
        public string MobileNo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email ID")]
        public string EmailId { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public Nullable<int> DeptId { get; set; }

        public virtual DepartmentViewModel Department { get; set; }
    }
}
