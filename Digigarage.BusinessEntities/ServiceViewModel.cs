using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class ServiceViewModel
    {
        public int ServiceId { get; set; }
        [Required]
        [DisplayName("Service Name")]
        public string ServiceName { get; set; }
    }
}
