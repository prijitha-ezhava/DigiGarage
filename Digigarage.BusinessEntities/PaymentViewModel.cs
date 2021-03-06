using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public Nullable<int> BookingId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Date { get; set; }

        public virtual ServiceViewModel Service { get; set; }
        public virtual VehicleViewModel Vehicle { get; set; }
    }
}
