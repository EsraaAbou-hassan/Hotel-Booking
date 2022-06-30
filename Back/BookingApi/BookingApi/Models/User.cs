using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace BookingApi.Models
{
    public class User : IdentityUser
    {




        public string country { get; set; }


        public string city { get; set; }

        public string img { get; set; }

        //public bool isAdmin { get; set; } = false;



    }
}
