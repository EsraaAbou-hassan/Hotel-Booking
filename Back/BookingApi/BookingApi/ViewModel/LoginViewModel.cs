using System.ComponentModel.DataAnnotations;

namespace BookingApi.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password must be more than 6 letters and contain lower and uper CHaracter")]

        public string Password { get; set; }
        public bool IsPersisite{ get; set; }
    }
}
