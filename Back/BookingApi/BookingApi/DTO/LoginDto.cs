using System.ComponentModel.DataAnnotations;

namespace BookingApi.DTO
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password must be more than 6 letters and contain lower and uper CHaracter")]

        public string Password { get; set; }
    }
}
