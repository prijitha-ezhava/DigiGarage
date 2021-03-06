using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class BookingHistoryViewModel
    {
        public int HistoryId { get; set; }
        public Nullable<int> BookingId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        [Required]
        public Nullable<int> MechanicId { get; set; }

        public virtual DepartmentViewModel Department { get; set; }
        public virtual ServiceViewModel Service { get; set; }
        public virtual VehicleViewModel Vehicle { get; set; }
        public virtual BookingViewModel Booking { get; set; }
        public virtual MechanicViewModel Mechanic { get; set; }
    }
}
