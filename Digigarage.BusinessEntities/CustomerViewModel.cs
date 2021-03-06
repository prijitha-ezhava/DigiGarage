using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digigarage.BusinessEntities
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Phone no must be greater than 10 digit")]
        [MaxLength(10, ErrorMessage = "Phone no must be less than 10 digit")]
        [DisplayName("Mobile")]
        public string PhoneNo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email ID")]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
