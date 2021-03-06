using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class VehicleViewModel
    {
        public int VehicleId { get; set; }
        [Required]
        [DisplayName("Licence Plate No")]
        public string LicencePlate { get; set; }
        public string Color { get; set; }
        [Required]
        [DisplayName("Fuel Used")]
        public string FuelType { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Registration Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> RegistraionDate { get; set; }
        [Required]
        [MinLength(17, ErrorMessage = "Chassis no must be of exact 17 digit")]
        [MaxLength(17, ErrorMessage = "Chassis no must be of exact 17 digit")]
        [DisplayName("Chassis Number")]
        public string ChassiNo { get; set; }
        [DisplayName("Engine Number")]
        public string EngineNo { get; set; }
        [Required(ErrorMessage ="Customer Required")]
        public Nullable<int> CustomerId { get; set; }

        public virtual CustomerViewModel Customer { get; set; }
    }
}
