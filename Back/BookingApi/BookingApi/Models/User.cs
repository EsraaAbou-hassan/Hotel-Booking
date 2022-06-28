using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BookingApi.Models
{
    public class User: IdentityUser
    {

       
        [Required]
       
        public string country { get; set; }
        [Required]

        public string city { get; set; }

        public string img { get; set; }

        

       
        [Required]

        public bool isAdmin { get; set; } = false;


        
    }
}
