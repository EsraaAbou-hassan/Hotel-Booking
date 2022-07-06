using System.ComponentModel.DataAnnotations;
namespace BookingApi.DTO
{
    public class RegisterUserDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Password must be more than 6 letters and contain lower and uper CHaracter")]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and ConfirmPassword not matched")]

        public string ConfirmPassword { get; set; }

        public string country { get; set; }


        public string city { get; set; }


       

       
    }
}
