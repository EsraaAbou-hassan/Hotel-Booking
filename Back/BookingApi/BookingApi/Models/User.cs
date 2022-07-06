using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BookingApi.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string country { get; set; }


        public string city { get; set; }

        public string img { get; set; }

        public int visaNumber { get; set; }
        public int visapassword { get; set; }





    }
}
