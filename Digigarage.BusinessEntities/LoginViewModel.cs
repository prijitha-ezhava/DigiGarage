using System.ComponentModel.DataAnnotations;

namespace Digigarage.BusinessEntities
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email Id required")]
        public string emailid { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }
    }
}
